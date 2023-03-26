using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyController>();
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (enemy != null)
           {
               Debug.Log("attack");
               enemy.EnemyDeath();
           }
        }
    }
}
