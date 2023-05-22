using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour //Her level geçişinde otomatik olarak NavMesh Bake'i alınıyor
{
    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;

    void Update()
    {
        SimultaneouslyBaker();
    }

    private void SimultaneouslyBaker()
    {
        for (int j = 0; j < objectsToRotate.Length; j++)
        {
            objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, 50 * Time.deltaTime, 0) +
                                                                objectsToRotate[j].localRotation.eulerAngles);
        }

        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
}