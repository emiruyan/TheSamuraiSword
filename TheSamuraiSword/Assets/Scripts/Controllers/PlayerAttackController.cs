using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttackController : MonoBehaviour //Player weapon'a atanmış bir class
{
    [Header("Audio")]
    [SerializeField] private AudioClip swordSlashClip;
    
    [Header("VFX")]
    public ParticleSystem playerAttackFx; 
    
    private void OnTriggerEnter(Collider other)//Player weapon ile Enemy çarpışma denetleyici
    {
        var enemy = other.gameObject.GetComponent<EnemyController>();
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (enemy != null)
           {
               enemy.EnemyDeath();
               playerAttackFx.transform.position = transform.position;
               SoundManager.Instance.PlaySound(swordSlashClip);
               playerAttackFx.Play();
           }
        }
    }
}
