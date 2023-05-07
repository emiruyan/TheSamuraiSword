using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
   [Header("Classes")]
   public PlayerController playerController;
   public JoystickController joystickController;
   public EnemyController enemyController;
   public SpawnController spawnController;
   public ObjectPoolPattern objectPoolPattern; 
   public PlayerAttackController playerAttackController;
   public Level level;
   public EnemyDeathCounter enemyDeathCounter;
   public DropController dropController;
   

   [Header("Ui's")] 
   public GameObject gameOverPanel;
  

   public List<EnemyController> enemyList;

   

   public void RemoveEnemy(EnemyController enemy)
   {
      enemyList.Remove(enemy);
   }

   public void TryAgainButton()
   {
      SceneManager.LoadScene("MapDesign");
   }
   
}
