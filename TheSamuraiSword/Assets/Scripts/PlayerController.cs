using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float speed;
  [SerializeField] private DynamicJoystick joystick;
  [SerializeField] private Image joystickBg;
  public GameObject sword;
  public Transform rightHand;
  [SerializeField] private Rigidbody rb;
  private bool isRunning;
  private Animator playerAnimator;
  
   private void Awake()
  {
      playerAnimator = GetComponent<Animator>();
  }

  public void FixedUpdate()
  {
     PlayerMovement();
     PlayerRunAnimation();
  }

  private void PlayerMovement()
  {
      Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
      transform.Translate(direction * speed);

      if (joystickBg.gameObject.activeSelf)
      {
          isRunning = true;
          sword.transform.position = rightHand.position;
      }
      else
      {
          isRunning = false;
          sword.transform.position = transform.position;
      }
  }

  private void PlayerRunAnimation()
  {
    
      if (isRunning)
      {
          playerAnimator.SetBool("isRunning", true);
      }
      else
      {
          playerAnimator.SetBool("isRunning", false);
      }
  }
  
}

