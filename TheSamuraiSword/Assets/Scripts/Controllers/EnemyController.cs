using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{

    [Header("Enemy Components")]
    public NavMeshAgent enemyAi;
    public Collider enemyCollider;
    private Transform playerTransform;
    private Animator enemyAnim;
    [SerializeField] private Rigidbody enemyRigidbody;
    public List<int> enemyDamageList;
    
    [Header("Scriptable Variables")]
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private float enemyDistance; 
    public float enemySpeed;
    public int enemyHealth;
    public int enemyMaxHealth = 100;
    public int enemyDamage;
    public GameObject shuriken;
    
    [Header("Audio")]
    [SerializeField] private AudioClip deathClip;
    
    [Header("FX")]
    public ParticleSystem enemyDeadParticle;

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
        playerTransform = GameManager.Instance.playerController.transform;
        enemyType.health = 100;
    }

    private void Update()
    {
        EnemyRangeCalculate();
    }

    private void EnemyRangeCalculate()//Enemy ve Player arasındaki mesafeyi hesaplama
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
    
    private void EnemyMove()//Enemy Hareketi
    {
        enemyAi.SetDestination(playerTransform.position);
    }

    public void EnemyDeath()//Enemy Ölümü
    {
        enemyHealth -= 20;

        foreach (var damageValue in enemyDamageList)
        {
            if (damageValue == enemyHealth)
            {
                enemyAnim.SetTrigger("GetHit");
            }
        }
        if (enemyHealth <= 0)
        {
            enemyCollider.enabled = false;
            GameManager.Instance.enemyDeathCounter.EnemyCounter();
            enemyAnim.SetBool("isDead",true);
            enemyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            InstantiateShuriken();
            enemyDeadParticle.Play();
            enemyAi.Stop();
            SoundManager.Instance.PlaySound(deathClip);
            StartCoroutine(DestroyEnemy());
            GameManager.Instance.RemoveEnemy(this);
            LevelManager.Instance.LevelWinCondition();
            
        }
    }

    private IEnumerator DestroyEnemy()//Enemy Yok oluşu
    {
        yield return new WaitForSeconds(1.8f);
        gameObject.SetActive(false);
    }
    public void InstantiateShuriken()//Enemyden düşen shuriken üretimi
    {
        GameObject cloneShuriken = Instantiate(shuriken,new Vector3(transform.position.x,1,transform.position.z) ,transform.rotation);
    }
}


