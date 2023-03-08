using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
  [SerializeField] private PlayerController playerController;
  [SerializeField] private JoystickController joystickController;
  [SerializeField] public RaycastController rayController;
}
