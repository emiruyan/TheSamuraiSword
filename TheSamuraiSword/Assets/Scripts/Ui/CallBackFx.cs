using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBackFx : MonoBehaviour
{
    public void OnParticleSystemStopped()
    {
        transform.SetSiblingIndex(transform.parent.childCount);
        transform.gameObject.SetActive(false);
    }
}
