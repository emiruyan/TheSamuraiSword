using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCardOpener : MonoBehaviour
{
    private Animator animationCardOpen;

    public GameObject CardPack;


    private void Awake()
    {
        animationCardOpen = CardPack.GetComponent<Animator>();
    }

    public void PlayCardOpen()
    {
        animationCardOpen.SetBool("isOpen", true);
    }

    public void PlayCardClosed()
    {
        animationCardOpen.SetBool("isOpen", false);
    }
}
