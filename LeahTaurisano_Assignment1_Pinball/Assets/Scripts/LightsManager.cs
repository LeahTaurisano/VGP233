using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    [SerializeField] LightSwitch switchOne, switchTwo, switchThree;

    private float lightDelay = 0.25f;
    private static float lightAnimationTimer = 5;
    private static float animationTimer = 0.0f;
    private float lightTimer;

    // Update is called once per frame
    void Update()
    {
        if (switchOne.IsActive() && switchTwo.IsActive() && switchThree.IsActive())
        {
            switchOne.SetLight(true);
            switchTwo.SetLight(false);
            switchThree.SetLight(false);
            BallManager.SetMultiball(true);
            BallManager.IncNumMultiballs(1);
        }
        if (BallManager.IsMultiballActive() && animationTimer <= lightAnimationTimer)
        {
            LightAnimation();
        }
        if (BallManager.GetGameOver())
        {
            ResetLights();
        }
    }

    private void LightAnimation()
    {
        lightTimer += Time.deltaTime;
        if (lightTimer >= lightDelay)
        {
            if (switchOne.IsActive())
            {
                switchOne.SetLight(false);
                switchTwo.SetLight(true);
            }
            else if (switchTwo.IsActive())
            {
                switchTwo.SetLight(false);
                switchThree.SetLight(true);
            }
            else
            {
                switchThree.SetLight(false);
                switchOne.SetLight(true);
            }
            lightTimer = 0.0f;
        }
        animationTimer += Time.deltaTime;
        if (animationTimer >= lightAnimationTimer)
        {
            ResetLights();
        }
    }

    public static float GetAnimationTimer()
    {
        return lightAnimationTimer;
    }

    public static void ResetAnimationTimer()
    {
        animationTimer = 0.0f;
    }

    private void ResetLights()
    {
        switchOne.SetLight(false);
        switchTwo.SetLight(false);
        switchThree.SetLight(false);
    }
}
