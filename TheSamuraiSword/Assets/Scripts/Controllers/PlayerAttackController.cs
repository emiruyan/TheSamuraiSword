using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttackController : MonoBehaviour
{
    public ParticleSystem playerAttackFx; 
    [SerializeField] private AudioClip swordSlashClip;
    
    private void OnTriggerEnter(Collider other)
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
