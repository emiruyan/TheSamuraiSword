using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float lerpTime;
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position - playerTransform.transform.position;
    }

    private void Update()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, playerTransform.position + offset, lerpTime * Time.deltaTime);
        transform.position = newPos;
    }
}
