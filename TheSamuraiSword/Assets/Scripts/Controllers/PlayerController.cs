using System;
using System.Collections;
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
    [SerializeField] private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField] private JoystickController Joystick; 
    [SerializeField] public NavMeshAgent playerAi;
    [SerializeField] private ParticleSystem playerDeadFX;
     public int playerHealth;
    public int playerMaxHealth= 100;
    public Animator playerAnimator;
   

    private Finger MovementFinger;
    public Vector2 MovementAmount;

    

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
        BlockEnemyHit();
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

    private void HandleFingerMove(Finger MovedFinger)
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
        }
    }

    private void HandleLoseFinger(Finger LostFinger)
    {
        if (LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Joystick.Knob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
        }
    }

    private void HandleFingerDown(Finger TouchedFinger)
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

    private Vector2 ClampStartPosition(Vector2 StartPosition)
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

    private void PlayerRangeCalculate()
    {
        var enemies = GameManager.Instance.enemyList;
       

        for (int i = 0; i < enemies.Count; i++)
        {
            float minDistance = 3f;
            float distance = Vector3.Distance(enemies[i].transform.position, transform.position);

            if (distance < minDistance)
            {
                playerAnimator.SetBool("isAttack",true);
//                playerAnimator.SetBool("isHit",false);
               
                break;
            }
            else
            {
                playerAnimator.SetBool("isAttack",false);
            }
        }
        
    }

     public void PlayerDead()
     {
         playerHealth -= 10;
 
         if (playerHealth == 0)
         {
             playerAnimator.SetBool("isPlayerDead", true);
             Time.timeScale = .5f;
             playerDeadFX.Play();
             playerAi.speed = 0;
             StartCoroutine(GameOverPanel());
         }
    }

     IEnumerator GameOverPanel()
     {
         yield return new WaitForSeconds(1.5f);
         GameManager.Instance.gameOverPanel.SetActive(true);
         
     }

     public void BlockEnemyHit()
     {
         if (playerHealth == 75)
         {
             Debug.Log("dfhgddh");
             playerAnimator.SetInteger("playerHealth",75);
         }

         if (playerHealth == 50)
         {
             playerAnimator.SetInteger("playerHealth",50);
         }

         if (playerHealth == 25)
         {
             playerAnimator.SetInteger("playerHealth",25);
         }
     }
     
}


