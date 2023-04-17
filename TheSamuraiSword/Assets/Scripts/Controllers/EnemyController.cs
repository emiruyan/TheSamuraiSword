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
    [SerializeField] private ParticleSystem enemyDeadParticle;
    
    public NavMeshAgent enemyAi;
    Transform playerTransform;
    private Animator enemyAnim;
    private Rigidbody enemyRb;

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
        enemyRb = GetComponent<Rigidbody>();
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
            
            enemyAnim.SetBool("isDead",true);
            enemyDeadParticle.Play();
            StartCoroutine(DestroyEnemy());
            GameManager.Instance.RemoveEnemy(this);
        }
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.8f);
        gameObject.SetActive(false);

    }
}
