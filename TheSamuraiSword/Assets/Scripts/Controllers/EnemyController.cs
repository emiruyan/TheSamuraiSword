using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemyAi;
    Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameManager.Instance.playerController.transform;
    }

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        enemyAi.SetDestination(playerTransform.position);
    }
}
