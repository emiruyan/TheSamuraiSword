using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DropController : MonoBehaviour
{
  
   

   private void Awake()
   {
      
   }

   public void RotateShuriken()
   {
    GameManager.Instance.enemyController.shuriken.transform.DORotate(Vector3.negativeInfinity, -1);
   }
}
