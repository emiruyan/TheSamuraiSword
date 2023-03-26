using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private float enemyDistance;
    
    public NavMeshAgent enemyAi;
    Transform playerTransform;
    private Animator enemyAnim;

    [Header("Scriptable Variables")]
    public float enemySpeed;
    public int enemyHealth;
    public int enemyDamage;

    private void Start()
    {
        GameManager.Instance.enemyList.Add(this);
        enemySpeed = enemyType.speed;
        enemyHealth = enemyType.health;
        enemyDamage = enemyType.damage;

        enemyType.health = 100;
    }

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        playerTransform = GameManager.Instance.playerController.transform;
    }

    private void Update()
    {
        EnemyRangeCalculate();
    }

    private void EnemyRangeCalculate()
    {
        float minDistance = enemyDistance;
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        
        if (distance < minDistance)
        {
            transform.LookAt(playerTransform);
            enemyAi.speed = 0;
            enemyAnim.SetBool("isInRange",true);
        }
        else
        {
            EnemyMove();
            enemyAnim.SetBool("isInRange", false);
            enemyAi.speed = 7;
        }
    }
    
    private void EnemyMove()
    {
        enemyAi.SetDestination(playerTransform.position);
    }

    public void EnemyDeath()
    {
        enemyType.health -= 30;

        if (enemyType.health <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.RemoveEnemy(this);
        }
    }
}
