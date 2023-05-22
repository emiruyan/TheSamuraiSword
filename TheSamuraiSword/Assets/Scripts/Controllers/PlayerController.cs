using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Serialization;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField] private JoystickController Joystick;
    private Finger MovementFinger;
    public Vector2 MovementAmount;

    [Header("Audio")]
    [SerializeField] private AudioClip healtPickUpSfx;
    [SerializeField] private AudioClip playerDeadSound;
    
    [Header("FX")]
    [SerializeField] private ParticleSystem playerDeadFX;
    [SerializeField] private ParticleSystem playerHealthFx;
    [SerializeField] private Transform footStep;
    
    [Header("Player Components")]
    public int playerHealth;
    public int playerMaxHealth = 100;
    public NavMeshAgent playerAi;
    public Animator playerAnimator;
    public List<int> damageAnimationList;
    
    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        Vector3 scaledMovement = playerAi.speed * Time.deltaTime * new Vector3(
            MovementAmount.x,
            0,
            MovementAmount.y
        );

        playerAi.transform.LookAt(playerAi.transform.position + scaledMovement, Vector3.up);
        playerAi.Move(scaledMovement);
        playerAnimator.SetFloat("moveX", MovementAmount.x);
        playerAnimator.SetFloat("moveZ", MovementAmount.y);
        
      

        PlayerRangeCalculate();
    }
    

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleLoseFinger;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }

    private void HandleFingerMove(Finger MovedFinger)//Parmak hareket ettirildiğinde
    {
        if (MovedFinger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2f;
            ETouch.Touch currentTouch = MovedFinger.currentTouch;

            if (Vector2.Distance(
                    currentTouch.screenPosition,
                    Joystick.RectTransform.anchoredPosition
                ) > maxMovement)
            {
                knobPosition = (
                                   currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition
                               ).normalized
                               * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition;
            }

            Joystick.Knob.anchoredPosition = knobPosition;
            MovementAmount = knobPosition / maxMovement;
            if (!footStep.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                footStep.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void HandleLoseFinger(Finger LostFinger)//Parmak ekrandan çekildiğinde
    {
        if (LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Joystick.Knob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
        }
    }

    private void HandleFingerDown(Finger TouchedFinger) //Parmağı ilk dokunuş
    {
        if (MovementFinger == null && TouchedFinger.screenPosition.x <= Screen.width / 2f)
        {
            MovementFinger = TouchedFinger;
            MovementAmount = Vector2.zero;
            Joystick.gameObject.SetActive(true);
            Joystick.RectTransform.sizeDelta = JoystickSize;
            Joystick.RectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
        }
    }

    private Vector2 ClampStartPosition(Vector2 StartPosition)//Başlangıç pozisyonu
    {
        if (StartPosition.x < JoystickSize.x / 2)
        {
            StartPosition.x = JoystickSize.x / 2;
        }

        if (StartPosition.y < JoystickSize.y / 2)
        {
            StartPosition.y = JoystickSize.y / 2;
        }
        else if (StartPosition.y > Screen.height - JoystickSize.y / 2)
        {
            StartPosition.y = Screen.height - JoystickSize.y / 2;
        }

        return StartPosition;
    }

    private void PlayerRangeCalculate()//Player ve Enemy mesafe hesaplama
    {
        var enemies = GameManager.Instance.enemyList;
       

        for (int i = 0; i < enemies.Count; i++)
        {
            float minDistance = 3f;
            float distance = Vector3.Distance(enemies[i].transform.position, transform.position);

            if (distance < minDistance)
            {
                playerAnimator.SetBool("isAttack",true);

                break;
            }
            else
            {
                playerAnimator.SetBool("isAttack",false);
            }
        }
        
    }

     public void PlayerDead()//Player Ölümü
     {
         playerHealth -= 10;
         foreach (var damageValue in damageAnimationList)
         {
             if (damageValue==playerHealth)
             {
                 playerAnimator.SetTrigger("GetHit");
             }
         }
         
         if (playerHealth == 0)
         {
             playerAnimator.SetBool("isPlayerDead", true);
             SoundManager.Instance.PlaySound(playerDeadSound);
             Time.timeScale = .5f;
             playerDeadFX.Play();
             playerAi.speed = 0;
             StartCoroutine(GameOverPanel());
         }
    }

     IEnumerator GameOverPanel()//Game Over UI
     {
         yield return new WaitForSeconds(1.5f);
         GameManager.Instance.gameOverPanel.SetActive(true);
         

     }
     private void OnTriggerEnter(Collider other)//Playerın health ile çarpışması
     {
         if (other.gameObject.CompareTag("Health"))
         {
             SoundManager.Instance.PlaySound(healtPickUpSfx);
             playerHealth += 40;
             playerHealthFx.Play();
             Destroy(other.gameObject);
             playerHealthFx.Stop();
         }
     }
}


