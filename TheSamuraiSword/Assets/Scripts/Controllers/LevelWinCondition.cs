using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinCondition : MonoBehaviour
{
    [SerializeField] private int nextLevelCount;
    public int winCount;
   

    private void Awake()
    {
    }

    private void Update()
    {
       // NextLevelCondition();
    }

    private void NextLevelCondition()
    {
        if (GameManager.Instance.level.spawnCount == nextLevelCount)
        {
            Debug.Log("level win");
        }
    }
}
