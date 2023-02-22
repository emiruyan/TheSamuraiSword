using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChestOpener : MonoBehaviour
{
    private Animator animationChestOpen;

    public GameObject Chest;


    private void Awake()
    {
        animationChestOpen = Chest.GetComponent<Animator>();
    }

    public void PlayAnimChest()
    {
        StartCoroutine(PlayChestOpen());
    }

    private IEnumerator PlayChestOpen()
    {
        AnimatorStateInfo chestOpenLength = animationChestOpen.GetCurrentAnimatorStateInfo(1);

        animationChestOpen.SetBool("isOpen", true);

        yield return new WaitForSeconds(chestOpenLength.normalizedTime);

        animationChestOpen.SetBool("isOpenLoop", true);
    }
}
