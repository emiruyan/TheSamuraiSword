using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndCondition : MonoBehaviour
{
    //Level sonunda yer alan bir Collider'da bulunan bir class
    [Header("Components")]
    public Collider levelEndCollider;
    public GameObject levelWinPanel;
    
    [Header("VFX")]
    public ParticleSystem levelEndParticle1;
    public ParticleSystem levelEndParticle2;
    public Light levelEndLight1;
    public Light levelEndLight2;
    
    [Header("Texts")]
    public Text enemyWinCounter;
    private bool isLevelEnd = false;

    private void Start()
    {
        levelEndParticle1.Stop();
        levelEndParticle2.Stop();
    }

    private void Update()
    {
        ActiveCollider();
    }

    private void OnTriggerEnter(Collider other)//Level Bitiş Collider'ı ile Playerın çarpışması
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

    public void NextLevelButton()//Bir sonraki levele geçiş butonu
    {
        LevelManager.Instance.LevelFinish();
    }

    IEnumerator LevelWinPanel()//Bölüm başarı ile tamamlandığında açılan panel
    {
        yield return new WaitForSeconds(4f);
        enemyWinCounter.text = GameManager.Instance.enemyDeathCounter.enemyDeathBar.value.ToString();
        levelWinPanel.SetActive(true);
    }

    private void ActiveCollider()//Level Bitiş Collider'ı aktif hale getirme
    {
        var enemies = GameManager.Instance.enemyList;
        
        if (!isLevelEnd)
        {
            if (enemies.Count == 0)
            {
                levelEndCollider.isTrigger = true;
                isLevelEnd = true;
            }
        }
    }
}
