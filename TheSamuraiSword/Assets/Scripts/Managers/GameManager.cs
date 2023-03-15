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
}
