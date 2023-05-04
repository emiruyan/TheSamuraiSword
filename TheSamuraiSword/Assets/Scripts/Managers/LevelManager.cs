using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoSingleton<LevelManager>
{
    [HideInInspector] public Level currentLevel;
    public bool isTestLevel;
    public bool isLevelLoop;
    public List<Level> levels;
    public Level testLevel;
    [Space] [Header("Events")]
    public UnityEvent levelCreated;
    public UnityEvent levelStarted;
    public UnityEvent levelFinished;

    private void Start()
    {
        LevelCreate();
    }

    public void ResourcesLoadLevel()
    {
        levels = Resources.LoadAll("level", typeof(Level)).Cast<Level>().ToList();
    }

    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }


    [ContextMenu("LevelCreate")]
    public void LevelCreate()
    {
        if (currentLevel != null)
            Destroy(currentLevel.gameObject);

        if (isTestLevel)
            CreateTestLevel();
        else
            CreateNormalLevel();

        levelCreated.Invoke();
        currentLevel.LevelStart();
    }

    public void LevelStart()
    {
        levelStarted.Invoke();
    }

    [ContextMenu("LevelFinish")]
    public void LevelFinish()
    {
        SetLevel();
        levelFinished.Invoke();
        SceneManager.LoadScene("MapDesign");
    }

    public void SetLevel()
    {
        PlayerPrefs.SetInt(Constants.LevelKey, GetLevel() + 1);
    }

    public int GetLevel()
    {
        var level = PlayerPrefs.GetInt(Constants.LevelKey, 0);
        return level;
    }

    private void CreateNormalLevel()
    {
        if (GetLevel() >= levels.Count)
        {
            if (isLevelLoop)
                PlayerPrefs.DeleteKey(Constants.LevelKey);
            else
                return;
        }

        var level = Instantiate(levels[GetLevel()], transform);
        level.gameObject.name = $"Level {GetLevel() + 1}";
        currentLevel = level;
    }

    private void CreateTestLevel()
    {
        if (testLevel != null)
        {
            var level = Instantiate(testLevel, transform);
            level.gameObject.name = $"Test{testLevel.name}";
            currentLevel = level;
        }
        else
            Debug.LogError("Test level is null");
    }
    public void LevelWinCondition()
    {
        var enemies = GameManager.Instance.enemyList;
        var playeranim = GameManager.Instance.playerController.playerAnimator;
        
        if (enemies.Count == 0)
        {
            Debug.Log("next level");
            playeranim.SetBool("isAttack",false);
        }
    }
}