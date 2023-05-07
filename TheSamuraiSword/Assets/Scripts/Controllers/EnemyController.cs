using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private float enemyDistance; 
    public ParticleSystem enemyDeadParticle;
    public Collider enemyCollider;
    public Transform enemyTransform;
    public GameObject shuriken;
    
    public NavMeshAgent enemyAi;
    Transform playerTransform;
    private Animator enemyAnim;
    private Rigidbody enemyRb;

    [Header("Scriptable Variables")]
    public float enemySpeed;
    public int enemyHealth;
    public int enemyMaxHealth = 100;
    public int enemyDamage;

    private void Start()
    {
        GameManager.Instance.enemyList.Add(this);
        enemySpeed = enemyType.speed;
        enemyHealth = enemyType.health;
        enemyDamage = enemyType.damage;
    }

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
        enemyTransform = GetComponent<Transform>();
        playerTransform = GameManager.Instance.playerController.transform;
        enemyType.health = 100;
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
        enemyHealth -= 30;
        

        if (enemyHealth <= 0)
        {
            enemyCollider.enabled = false;
            GameManager.Instance.enemyDeathCounter.EnemyCounter();
            enemyAnim.SetBool("isDead",true);
            Instantiate(shuriken,new Vector3(transform.position.x,1,transform.position.z) ,transform.rotation);
            enemyDeadParticle.Play();
            enemyAi.Stop();
            StartCoroutine(DestroyEnemy());
            GameManager.Instance.RemoveEnemy(this);
            LevelManager.Instance.LevelWinCondition();
            
        }
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.8f);
        gameObject.SetActive(false);
    }
}
