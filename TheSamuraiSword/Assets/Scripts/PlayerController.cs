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

  public void FixedUpdate()
  {
     PlayerMovement();
  }

  private void PlayerMovement()
  {
     // Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
     // rb.velocity = direction * speed * Time.fixedDeltaTime;
     //
     // transform.rotation = Quaternion.identity;

     rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);

     if (joystick.Horizontal != 0 || joystick.Vertical != 0)
     {
         transform.rotation = Quaternion.LookRotation(rb.velocity);
     }
  }                                                                                     
}

