using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
  //Spawn lokasyonlarımızı bir Transform dizisi üzerinde tutup belirli zaman aralığında ve random enemy olarak spawn ediyoruz. 
  
  [SerializeField] public float spawnInterval;
  [SerializeField] private ObjectPoolPattern objectPoolPattern = null;
  public Transform[] spawnLocation;
  private int counter = 0;
  
  private void Start()
  {
    StartCoroutine(nameof(SpawnRoutine));
  }

  private IEnumerator SpawnRoutine() 
  {
    while (true)
    {
      GameObject newEnemy = objectPoolPattern.GetPoolObject(counter++ % 5);
      yield return new WaitForSeconds(spawnInterval);
    }
  }
  
}
