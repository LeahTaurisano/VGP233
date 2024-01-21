using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI multiText;
    [SerializeField] private TextMeshProUGUI highscoreText;


    private static int score = 0;
    private static float multiplier = 1.0f;
    private static int highScore = 0;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        multiText.text = multiplier.ToString("F2") + "x";
        highscoreText.text = "Highscore: \n" + highScore.ToString();
    }

    public static void IncreaseScore(float points)
    {
        score += (int)(points * multiplier);
    }

    public static void IncreaseMultiplier(float multi)
    {
        multiplier += Mathf.Round(multi * 100.0f) / 100.0f;
    }

    public static void ResetMultiplier()
    {
        multiplier = 1.0f;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void ResetScore()
    {
        score = 0;
    }

    public static int GetHighscore()
    {
        return highScore;
    }

    public static void SetHighscore()
    {
        highScore = score;
    }
}
