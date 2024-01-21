using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class KillPinball : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;

    private int multiballsKilled = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pinball")
        {
            if (!BallManager.IsMultiballActive())
            {
                BallManager.SetActive(false);
                BallManager.LoseLife();
                if (BallManager.GetLives() >= 0)
                {
                    ScoreManager.ResetMultiplier();
                }
            }
            else
            {
                ++multiballsKilled;
                if (multiballsKilled >= BallManager.MaxMultiballs())
                {
                    BallManager.SetMultiball(false);
                    BallManager.SetActive(false);
                    BallManager.LoseLife();
                    if (BallManager.GetLives() >= 0)
                    {
                        ScoreManager.ResetMultiplier();
                    }
                    BallManager.IncNumMultiballs(-multiballsKilled);
                    LightsManager.ResetAnimationTimer();
                    multiballsKilled = 0;
                }
            }
            Destroy(collision.gameObject);
            if (BallManager.GetLives() <= 0)
            {
                BallManager.SetGameOver(true);
            }
        }
    }
}
