using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndCondition : MonoBehaviour
{
    public GameObject levelWinPanel;
    public Light levelEndLight1;
    public Light levelEndLight2;
    public ParticleSystem levelEndParticle1;
    public ParticleSystem levelEndParticle2;
    public Text enemyWinCounter;

    private void Start()
    {
        levelEndParticle1.Stop();
        levelEndParticle2.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerNavMesh = GameManager.Instance.playerController.playerAi;
        var playerAnim = GameManager.Instance.playerController.playerAnimator;
        
        playerAnim.SetTrigger("LevelEnd");
        levelEndLight1.gameObject.SetActive(true);
        levelEndLight2.gameObject.SetActive(true);
        levelEndParticle1.Play();
        levelEndParticle2.Play();
        playerNavMesh.speed = 0;
        StartCoroutine(LevelWinPanel());

    }

    public void NextLevelButton()
    {
        LevelManager.Instance.LevelFinish();
    }

    IEnumerator LevelWinPanel()
    {
        yield return new WaitForSeconds(4f);
        enemyWinCounter.text = GameManager.Instance.enemyDeathCounter.enemyDeathBar.value.ToString();
        levelWinPanel.SetActive(true);
    }
}
