using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoSingleton<GameManager>
{
   public PlayerController playerController;
   public JoystickController joystickController;
   public EnemyController enemyController;
   public SpawnController spawnController;
   public ObjectPoolPattern objectPoolPattern;
   [FormerlySerializedAs("attackController")] public PlayerAttackController playerAttackController;
   
   
   public List<EnemyController> enemyList;

   public void RemoveEnemy(EnemyController enemy)
   {
      enemyList.Remove(enemy);
   }
   
}
