using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pinball;
    [SerializeField] private PortalComponent portal;

    private float multiballDelay = 1.0f;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (!BallManager.IsBallActive() && BallManager.GetLives() > 0)
        {
            BallManager.SetActive(true);
            Instantiate(pinball, transform.position, Quaternion.identity);
        }
        
        if (BallManager.IsMultiballActive())
        {
            if (BallManager.NumMultiballsActive() < BallManager.MaxMultiballs())
            {
                timer += Time.deltaTime;
                if (timer >= multiballDelay)
                {
                    GameObject newPinball = Instantiate(pinball, transform.position, Quaternion.identity);
                    Rigidbody2D newPinballBody = newPinball.GetComponent<Rigidbody2D>();
                    BallManager.IncNumMultiballs(1);
                    portal.LaunchBall(newPinball, new Vector2(0, 5), newPinballBody);
                    timer = 0.0f;
                }
            }
        }
    }
}
