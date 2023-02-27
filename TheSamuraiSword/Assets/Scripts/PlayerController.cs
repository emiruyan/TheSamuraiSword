using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float speed;
  [SerializeField] private DynamicJoystick joystick;
  [SerializeField] private Rigidbody rb;
   private Animator playerAnimator;

  private void Awake()
  {
      playerAnimator = GetComponent<Animator>();
  }

  public void FixedUpdate()
  {
     PlayerMovement();
  }

  private void PlayerMovement()
  {
      Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
      transform.Translate(direction * speed);

      if (speed <= .1)
      {
          playerAnimator.SetFloat("Walk",speed);
      }
      if (speed <= .3)
      {
          playerAnimator.SetFloat("Run",speed);
      }
  }                                                                                     
}

