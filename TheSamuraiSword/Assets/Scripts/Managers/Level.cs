using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
   public int enemyCount;
   [SerializeField] public float spawnInterval;
   public Transform[] spawnLocation;
   private int counter = 0;
   public int spawnCount;
   
   public void LevelStart()
   {
      StartCoroutine(nameof(SpawnRoutine));
   }
   

   private IEnumerator SpawnRoutine() 
   {
      while (true)
      {
         spawnCount++;
         GameObject newEnemy = ObjectPoolPattern.Instance.GetPoolObject(Random.Range(0,ObjectPoolPattern.Instance.pools.Length));
         newEnemy.transform.position = spawnLocation[(Random.Range(0, spawnLocation.Length))].transform.position;
         if (spawnCount >= enemyCount)
         {
            StopAllCoroutines();
         }
         yield return new WaitForSeconds(spawnInterval);
      }
   }
}
