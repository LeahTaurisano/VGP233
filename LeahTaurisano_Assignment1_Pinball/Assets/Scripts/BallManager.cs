using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private static int maxLives = 3;
    [SerializeField] private TextMeshProUGUI livesText;

    private static int maxMultiballs = 5;
    private static bool ballIsActive = false;
    private static bool multiballIsActive = false;
    private static int numMultiballs = 0;
    private static int lives;
    private static bool gameOver = false;

    private void Start()
    {
        lives = maxLives;
        GameOverComponent.FlipGameOverScreen();
    }

    private void Update()
    {
        livesText.text = "x" + lives.ToString();
    }

    public static int NumMultiballsActive()
    {
        return numMultiballs;
    }

    public static bool IsBallActive()
    {
        return ballIsActive;
    }

    public static bool IsMultiballActive()
    {
        return multiballIsActive;
    }

    public static int MaxMultiballs()
    {
        return maxMultiballs;
    }

    public static void IncNumMultiballs(int num)
    {
        numMultiballs += num;
    }

    public static void SetActive(bool active)
    {
        ballIsActive = active;
    }

    public static void SetMultiball(bool active)
    {
        multiballIsActive = active;
    }

    public static int GetLives()
    {
        return lives;
    }

    public static void LoseLife()
    {
        --lives;
    }

    public static void ResetLives()
    {
        lives = maxLives;
    }    

    public static int GetMaxLives()
    {
        return maxLives;
    }

    public static bool GetGameOver()
    {
        return gameOver;
    }

    public static void SetGameOver(bool state)
    {
        gameOver = state;
        if (ScoreManager.GetHighscore() < ScoreManager.GetScore())
        {
            ScoreManager.SetHighscore();
        }
        GameOverComponent.FlipGameOverScreen();
    }
}
