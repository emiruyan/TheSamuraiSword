using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShurikenUi : MonoBehaviour
{ 
    public Transform iconTransform;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public Vector3 GetIconPosition(Vector3 target)//Toplanan shurikenleri yolladığımız UI pozisyonu
    {
        Vector3 uiPos = iconTransform.position;
        uiPos.z = (target - mainCamera.transform.position).z;

        Vector3 result = mainCamera.ScreenToWorldPoint(uiPos);
        return result;
    }
}
