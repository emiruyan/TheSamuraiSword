using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DropController : MonoBehaviour
{
    
    [Header("Audio")]
    [SerializeField] private AudioClip collectSfx;
    
    public bool collected = false;
    
    private void LateUpdate()//ShurikenUi classı ve LateUpdate Shurikeni toplamayı ve Ui üzerine göndermeyi denetliyor
    {
        if (collected)
        {
            Vector3 targetPos = GameManager.Instance.shurikenUi.GetIconPosition(transform.position);
            if (Vector2.Distance(transform.position, targetPos) > 2f)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10f);
            }
            else
            {
                Destroy(this.gameObject);
                GameManager.Instance.score++;
                GameManager.Instance.scoreTextTmp.text = GameManager.Instance.score.ToString();
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)//Player ve shuriken çarpışma denetleyici
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(collectSfx);
            transform.parent = Camera.main.transform;
            transform.DOScale(new Vector3(2, 2, 2), 1);
            collected = true;
        }
    }
}
