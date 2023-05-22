using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour //Enemy weapon'a atanmış bir class
{
    [SerializeField] private AudioClip swordAttackClip;
    private void OnTriggerEnter(Collider other)//Enemy weapon ve Player çarpışması denetleyici
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.playerController.PlayerDead();//Player'ın canını azaltma ve öldürme işlemini Player üzerinden kontrol ediyoruz
            SoundManager.Instance.PlaySound(swordAttackClip);
        }
  
    }
}
