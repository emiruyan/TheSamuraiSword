using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPoolPattern : MonoSingleton<ObjectPoolPattern>
{
    [Serializable] //Inspector'da görüntüleyebiliyoruz
    public struct
        Pool //Birden fazla obje'yi pool'a atmak için struck oluşturduk, değerlerimizi buna taşıdık ve bundan bir Array oluşturacağız
    {
        public GameObject enemyPrefab; //Çoğalacak nesnelerimizi prefab şeklinde tutacağız
        public Queue<GameObject> pooledObjects; //Objelerimizi sıraya sokmak için Queue oluşturduk
        public int poolSize;
    }

    [SerializeField] public Pool[] pools = null;


    private void Awake()
    {
        InstantiateObject();
    }

    public void InstantiateObject()
    {
        
        for (int j = 0; j < pools.Length; j++) //Bu döngü pools dizimizin uzunluğu kadar çalışacak
        {
            pools[j].pooledObjects = new Queue<GameObject>(); //Yeni bir Queue oluşturduk
            

            for (int i = 0; i < pools[j].poolSize; i++) //poolSize uzunluğunda bir döngüye sokuyoruz
            {
                GameObject newEnemy = Instantiate(pools[j].enemyPrefab); //Öncelikle prefableri Instantiete ediyoruz
                newEnemy.SetActive(false); //Bu objeleri ilk önce kullanmayacağız sahnede kapalı şekilde bekleyecek


                pools[j].pooledObjects.Enqueue(newEnemy); //Objelerimizi Enqueue ile sıraya sokuyoruz
            }
        }
    }

    public GameObject GetPoolObject(int objectType) //Sıradaki objelerimizi buradan çekeceğiz
    {
        if (objectType >= pools.Length) //objectType pools dizimizin uzunluğuna büyük eşit ise;
        {
            return null; //null dönsün
        }
    
        GameObject newEnemy = pools[objectType].pooledObjects.Dequeue(); //İlk sıradaki objeyi çağırıyoruz
    
        newEnemy.SetActive(true); //Bu objeyi kullanmaya başladığımız için SetActive(true) yaparak sahnede görünür hale getiriyoruz  
        pools[objectType].pooledObjects
            .Enqueue(newEnemy); //Enqueue ile objeyi daha sonra tekrar kullanmak için sıramızın tekrar en sonuna ekliyoruz
    
        return newEnemy;
    }
}
