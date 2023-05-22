using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    //Bir int değişkeni olan ve Enemy üzerinde bulunan health değişkenimizi Ui olarak Can barımızda kullanmamızı sağlayan class
    public EnemyController enemyController;
    public Slider enemyHealthBar;

    private void Awake()
    {
        enemyHealthBar.maxValue = enemyController.enemyMaxHealth;
    }

    private void Update()
    {
        HealthCalculate();
    }

    public void HealthCalculate()
    {
        transform.forward = Camera.main.transform.forward;
        enemyHealthBar.transform.LookAt(enemyHealthBar.transform.position + Camera.main.transform.forward);
        enemyHealthBar.maxValue = enemyController.enemyMaxHealth;
        enemyHealthBar.value = enemyController.enemyHealth;
        if (enemyController.enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

