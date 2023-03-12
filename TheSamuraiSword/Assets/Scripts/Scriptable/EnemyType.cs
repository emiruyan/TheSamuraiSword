using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy",menuName = "Enemy Type")]
public class EnemyType : ScriptableObject
{
    public float speed;
    public int health;
    public int damage;
}

