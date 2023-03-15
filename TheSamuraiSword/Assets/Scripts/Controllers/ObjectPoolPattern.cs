using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPoolPattern : MonoBehaviour
{
    [Serializable] 
    public struct
        Pool 
    {
        public GameObject enemyPrefab; 
        public Queue<GameObject> pooledObjects; 
        public int poolSize;
    }

    [SerializeField] private Pool[] pools = null;


    private void Awake()
    {
        InstantiateObject();
    }

    private void InstantiateObject()
    {
        
        for (int j = 0; j < pools.Length; j++) 
        {
            pools[j].pooledObjects = new Queue<GameObject>(); 
            
            var spawnLoc = GameManager.Instance.spawnController.spawnLocation;

            for (int i = 0; i < pools[j].poolSize; i++) 
            {
                GameObject newEnemy = Instantiate(pools[j].enemyPrefab,spawnLoc[j]); 
                newEnemy.SetActive(false); 


                pools[j].pooledObjects.Enqueue(newEnemy); 
            }
        }
    }

    public GameObject GetPoolObject(int objectType)
    {
        if (objectType >= pools.Length) 
        {
            return null;
        }

        GameObject newEnemy = pools[objectType].pooledObjects.Dequeue(); 

        newEnemy.SetActive(true);  

        pools[objectType].pooledObjects
            .Enqueue(newEnemy); 

        return newEnemy;
    }
}
