using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
   public PlayerController playerController;
   public JoystickController joystickController;
   public EnemyController enemyController;
   public SpawnController spawnController;
   public ObjectPoolPattern objectPoolPattern;
   public AttackController attackController;
   
   
   public List<EnemyController> enemyList;

   public void RemoveEnemy(EnemyController enemy)
   {
      enemyList.Remove(enemy);
   }
   
}
