using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDemoController : MonoBehaviour
{
    private Animator animationDemo;

    public GameObject GuiPack;


    private void Awake()
    {
        animationDemo = GuiPack.GetComponent<Animator>();
    }

    public void PlayBigKnights()
    {
        animationDemo.SetBool("isBigKnights", true);
    }

    public void PlayBigKnightsBack()
    {
        animationDemo.SetBool("isBigKnights", false);
    }

    public void PlayLittleKnights()
    {
        animationDemo.SetBool("isLittleKnights", true);
    }

    public void PlayLittleKnightsBack()
    {
        animationDemo.SetBool("isLittleKnights", false);
    }

    public void PlayShop()
    {
        animationDemo.SetBool("isShop", true);
    }

    public void PlayShopBack()
    {
        animationDemo.SetBool("isShop", false);
    }

    public void PlayCards()
    {
        animationDemo.SetBool("isCards", true);
    }

    public void PlayCardsBack()
    {
        animationDemo.SetBool("isCards", false);
    }

    public void PlayChests()
    {
        animationDemo.SetBool("isChests", true);
    }

    public void PlayChestsBack()
    {
        animationDemo.SetBool("isChests", false);
    }

    public void PlayInventory()
    {
        animationDemo.SetBool("isInventory", true);
    }

    public void PlayInventoryBack()
    {
        animationDemo.SetBool("isInventory", false);
    }

    public void PlayFlags()
    {
        animationDemo.SetBool("isFlags", true);
    }

    public void PlayFlagsBack()
    {
        animationDemo.SetBool("isFlags", false);
    }

    public void PlayLogin()
    {
        animationDemo.SetBool("isGuestLogin", true);
    }

    public void PlayFight()
    {
        StartCoroutine(PlayFightAnim());
    }

    private IEnumerator PlayFightAnim()
    {
        AnimatorStateInfo fightlength = animationDemo.GetCurrentAnimatorStateInfo(3);

        animationDemo.SetBool("isFight", true);

        yield return new WaitForSeconds(fightlength.normalizedTime);

        animationDemo.SetBool("isFight", false);
    }

    public void PlaySwordSlash()
    {
        StartCoroutine(PlaySlash());
    }

    private IEnumerator PlaySlash()
    {
        AnimatorStateInfo slashlength = animationDemo.GetCurrentAnimatorStateInfo(11);

        animationDemo.SetBool("isSwordSlash", true);

        yield return new WaitForSeconds(slashlength.normalizedTime);

        animationDemo.SetBool("isSwordSlash", false);
    }

    public void PlaySettings()
    {
        animationDemo.SetBool("isSettings", true);
    }

    public void PlaySettingsBack()
    {
        animationDemo.SetBool("isSettings", false);
    }

    public void PlayProfile()
    {
        animationDemo.SetBool("isProfile", true);
    }

    public void PlayProfilesBack()
    {
        animationDemo.SetBool("isProfile", false);
    }

    public void PlayPanels()
    {
        animationDemo.SetBool("isPanels", true);
    }

    public void PlayPanelsBack()
    {
        animationDemo.SetBool("isPanels", false);
    }

    public void PlayCurrencies()
    {
        animationDemo.SetBool("isCurrencies", true);
    }

    public void PlayCurrenciesBack()
    {
        animationDemo.SetBool("isCurrencies", false);
    }

    public void PlayCastle()
    {
        animationDemo.SetBool("isCastle", true);
    }

    public void PlayCastlesBack()
    {
        animationDemo.SetBool("isCastle", false);
    }

    public void PlayButtons()
    {
        animationDemo.SetBool("isButtons", true);
    }

    public void PlayButtonsBack()
    {
        animationDemo.SetBool("isButtons", false);
    }

    public void PlayComplete()
    {
        animationDemo.SetBool("isComplete", true);
    }

    public void PlayCompleteBack()
    {
        animationDemo.SetBool("isComplete", false);
    }
}
