using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPoolPattern : MonoSingleton<ObjectPoolPattern>
{
    [Serializable] 
    public struct
        Pool 
    {
        public GameObject enemyPrefab; 
        public Queue<GameObject> pooledObjects; 
        public int poolSize;
    }

    [SerializeField] public Pool[] pools = null;


    private void Awake()
    {
        InstantiateObject();
    }

    public void InstantiateObject()//Obje Spawn'ı
    {
        
        for (int j = 0; j < pools.Length; j++) 
        {
            pools[j].pooledObjects = new Queue<GameObject>(); 
            

            for (int i = 0; i < pools[j].poolSize; i++) 
            {
                GameObject newEnemy = Instantiate(pools[j].enemyPrefab); 
                newEnemy.SetActive(false);


                pools[j].pooledObjects.Enqueue(newEnemy); 
            }
        }
    }

    public GameObject GetPoolObject(int objectType)//Havuzdan obje çekme
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
