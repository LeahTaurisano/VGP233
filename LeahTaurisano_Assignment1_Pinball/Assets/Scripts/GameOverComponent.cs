using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverComponent : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private static Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas = gameOverUI.GetComponent<Canvas>();
    }

    private void Update()
    {
        if (BallManager.GetGameOver())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BallManager.SetGameOver(false);
                BallManager.ResetLives();
                ScoreManager.ResetScore();
            }
        }
    }

    public static void FlipGameOverScreen()
    {
        gameOverCanvas.enabled = !gameOverCanvas.enabled;
    }
}
