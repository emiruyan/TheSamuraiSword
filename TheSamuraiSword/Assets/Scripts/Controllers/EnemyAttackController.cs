using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //GameManager.Instance.playerController.PlayerDead();
           // GameManager.Instance.playerController.playerAnimator.SetTrigger("getHit");
        }
        else
        {
           // GameManager.Instance.playerController.playerAnimator.SetBool("isGetHit",false);
        }
    }
}
