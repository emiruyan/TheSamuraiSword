using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsController : MonoBehaviour
{
    public int tabCount;

    public void SetTabFront(GameObject tabObject)
    {
        tabObject.transform.SetSiblingIndex(tabCount);
    }
}
