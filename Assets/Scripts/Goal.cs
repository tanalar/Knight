using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private int blackGoal;
    [SerializeField] private int whiteGoal;
    [SerializeField] private int blackCounter = 0;
    [SerializeField] private int whiteCounter = 0;
    private int nextScene;

    public static Action onPlayerHitGoal;
    public static Action onLevelComplete;

    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnEnable()
    {
        BloomEffect.onMaxBloom += LevelComplete;

        HitChecker.onBlackHit += BlackHit;
        HitChecker.onBlackLeft += BlackLeft;
        HitChecker.onWhiteHit += WhiteHit;
        HitChecker.onWhiteLeft += WhiteLeft;
    }
    private void OnDisable()
    {
        BloomEffect.onMaxBloom -= LevelComplete;

        HitChecker.onBlackHit -= BlackHit;
        HitChecker.onBlackLeft -= BlackLeft;
        HitChecker.onWhiteHit -= WhiteHit;
        HitChecker.onWhiteLeft -= WhiteLeft;
    }

    private void BlackHit()
    {
        blackCounter++;
        GoalCheck();
    }
    private void BlackLeft()
    {
        blackCounter--;
        GoalCheck();
    }
    private void WhiteHit()
    {
        whiteCounter++;
        GoalCheck();
    }
    private void WhiteLeft()
    {
        whiteCounter--;
        GoalCheck();
    }
    private void GoalCheck()
    {
        if (blackCounter == blackGoal && whiteCounter == whiteGoal)
        {
            onPlayerHitGoal?.Invoke();
        }
    }

    private void LevelComplete()
    {
        PlayerPrefs.SetInt("CurrentLvl", nextScene);
        PlayerPrefs.SetInt("HelpIsActive", 0);
        if (nextScene > PlayerPrefs.GetInt("lvlAt", 1))
        {
            PlayerPrefs.SetInt("lvlAt", nextScene);
        }
        onLevelComplete?.Invoke();
    }
}
