using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailedPanel : MonoBehaviour
{
    public Text enemyCountText;

    private void OnEnable()
    {
        var enemies = GameManager.Instance.enemyDeathCounter.enemyDeathBar.value.ToString();
     
        
        enemyCountText.text = enemies;
       
    }
    
}
