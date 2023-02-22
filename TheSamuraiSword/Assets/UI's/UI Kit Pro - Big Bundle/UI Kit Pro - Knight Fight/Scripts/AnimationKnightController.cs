using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKnightController : MonoBehaviour
{
    private Animator animationKnights;

    public GameObject Knight;


    private void Awake()
    {
        animationKnights = Knight.GetComponent<Animator>();
    }

    public void PlayAnimAttack()
    {
        StartCoroutine(PlayAttack());
    }

    private IEnumerator PlayAttack()
    {
       AnimatorStateInfo attackLength = animationKnights.GetCurrentAnimatorStateInfo(1);
       
       animationKnights.SetBool("isAttack", true);

       yield return new WaitForSeconds(attackLength.normalizedTime);

       animationKnights.SetBool("isAttack", false);
    }

    public void PlayAnimHit()
    {
        StartCoroutine(PlayHit());
    }

    private IEnumerator PlayHit()
    {
        AnimatorStateInfo hitLength = animationKnights.GetCurrentAnimatorStateInfo(3);

        animationKnights.SetBool("isHit", true);

        yield return new WaitForSeconds(hitLength.normalizedTime);

        animationKnights.SetBool("isHit", false);
    }

    public void PlayAnimDead()
    {
        StartCoroutine(PlayDead());
    }

    private IEnumerator PlayDead()
    {
        AnimatorStateInfo deadLength = animationKnights.GetCurrentAnimatorStateInfo(4);

        animationKnights.SetBool("isDead", true);

        yield return new WaitForSeconds(deadLength.normalizedTime);

        animationKnights.SetBool("isDead", false);
    }

    public void PlayAnimWin()
    {
        StartCoroutine(PlayWin());
    }

    private IEnumerator PlayWin()
    {
        AnimatorStateInfo winLength = animationKnights.GetCurrentAnimatorStateInfo(6);

        animationKnights.SetBool("isWin", true);

        yield return new WaitForSeconds(winLength.normalizedTime);

        animationKnights.SetBool("isWin", false);
    }

    public void PlayAnimWalk()
    {
        StartCoroutine(PlayWalk());
    }

    private IEnumerator PlayWalk()
    {
        AnimatorStateInfo walkLength = animationKnights.GetCurrentAnimatorStateInfo(5);

        animationKnights.SetBool("isWalk", true);

        yield return new WaitForSeconds(walkLength.normalizedTime);

        animationKnights.SetBool("isWalk", false);
    }
}
