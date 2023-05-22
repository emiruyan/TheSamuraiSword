using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
   //GameManager classımız Singleton olduğu için bir çok class arasındaki haberleşmeyi GameManager üzerinden yapıyoruz
   [Header("Classes")]
   public PlayerController playerController;
   public JoystickController joystickController;
   public CameraController cameraController;
   public EnemyController enemyController;
   public SpawnController spawnController;
   public ObjectPoolPattern objectPoolPattern; 
   public PlayerAttackController playerAttackController;
   public Level level;
   public EnemyDeathCounter enemyDeathCounter;
   public DropController dropController;
   public ShurikenUi shurikenUi;

   [Header("Ui's")] 
   public GameObject gameOverPanel;
   public TextMeshProUGUI scoreTextTmp;
   public int score= 0;
   public TextMeshProUGUI tapToPlayText;
  
   [Header("List's")] 
   public List<EnemyController> enemyList;
   

   public void RemoveEnemy(EnemyController enemy)
   {
      enemyList.Remove(enemy);
   }

   public void TryAgainButton()//LevelFailedPanel Button
   {
      SceneManager.LoadScene("MapDesign");
   }
   
}
