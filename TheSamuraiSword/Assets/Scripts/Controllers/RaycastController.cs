using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    RaycastHit hit;

    private void Awake()
    {
        playerController.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        RaycastShot();
    }

    private void RaycastShot()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                playerController.playerAnimator.SetBool("isAttack",true);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                Debug.Log("Did Hit");
                
            }
        }
        else
        {
            playerController.playerAnimator.SetBool("isAttack",false);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5f, Color.red);
            Debug.Log("Did not Hit");
        }
    }
}
