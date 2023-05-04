using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
   public Slider playerHealthBar;
   public PlayerController playerController;

   private void Start()
   {
      playerHealthBar.maxValue = playerController.playerMaxHealth;
   }

   private void Update()
   {
      HealthBarCalculate();
   }

   public void HealthBarCalculate()
   {
      //transform.forward = Camera.main.transform.forward;
      playerHealthBar.transform.LookAt(playerHealthBar.transform.position + Camera.main.transform.forward);
      playerHealthBar.maxValue = playerController.playerMaxHealth;
      playerHealthBar.value = playerController.playerHealth;
      if (playerController.playerHealth <= 0 )
      {
         Destroy(gameObject);
      }

   }
}
