using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public ParticleSystem playerAttackFx;
    
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyController>();
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (enemy != null)
           {
               enemy.EnemyDeath();
               playerAttackFx.transform.position = transform.position;
               playerAttackFx.Play();
           }
        }
    }
}
