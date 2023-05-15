using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private AudioClip swordAttackClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.playerController.PlayerDead();
            SoundManager.Instance.PlaySound(swordAttackClip);
        }
  
    }
}
