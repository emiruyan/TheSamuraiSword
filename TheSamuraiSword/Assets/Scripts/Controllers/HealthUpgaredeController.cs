using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthUpgaredeController : MonoBehaviour
{
    public Transform[] healthLocations;
    public GameObject healthIncreaser;
    private int randomNum;
    [SerializeField] int lifetime;
    [SerializeField] private int repeatTime;

    private void Start()
    {
        InvokeRepeating("SpawnHealthPoint",0, repeatTime);
    }

    private void SpawnHealthPoint()
    {
        var health = GameManager.Instance.playerController.playerHealth;
        var enemyCount = GameManager.Instance.enemyList.Count;

        if (health <= 130 && enemyCount >= 1)
        {
            GameObject healthUpgrade = Instantiate(healthIncreaser);
            healthUpgrade.transform.DOMoveY(2.2f, 1f).From().SetLoops(-1, LoopType.Yoyo);
            healthUpgrade.transform.DOScale(new Vector3(3.2f, 3.2f, 3.2f), 1);
            healthUpgrade.transform.position = healthLocations[(Random.Range(0, healthLocations.Length))].transform.position;
            Destroy(healthUpgrade,lifetime);
        }
    }
}
