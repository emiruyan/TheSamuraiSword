using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathCounter : MonoBehaviour
{
    public Slider enemyDeathBar;
    
    private void Start()
    {
        enemyDeathBar.value = 0;
        enemyDeathBar.maxValue = GameManager.Instance.level.enemyCount;
    }
    
    public void EnemyCounter()//Her enemy öldürdüğümüzde arttırdığımız bir slider (Aynı zamanda LevelWin ve LevelFailed panellerde görüntülüyoruz)
    {
        enemyDeathBar.value++;
        transform.DOPunchScale(new Vector3(.2f, .2f, .2f), .25f).From();
    }
}
