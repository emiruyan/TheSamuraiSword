using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScreenScaler : MonoBehaviour
{
    public Transform WorldObject;
    public Transform CanvasObject;

    int CachedWidth;
    int CachedHeight;

    void Refresh()
    {
        CachedWidth = Screen.width;
        CachedHeight = Screen.height;
    }

    void Start()
    {
        Refresh();
    }

    void Update()
    {
        if (Screen.width == CachedWidth)
        {
            if (Screen.height == CachedHeight)
            {
                return;
            }
        }

        Refresh();
    }
}
