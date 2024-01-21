using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLauncher : MonoBehaviour
{
    [SerializeField] private float maxLauncherDelta;
    [SerializeField] private float launcherLowerVelocity;
    [SerializeField] private float launchVelocity;

    private Vector3 startPosition;
    private Rigidbody2D rigidBody;
    private bool launching = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (launching)
        {
            if (transform.position.y > (startPosition.y - maxLauncherDelta))
            {
                rigidBody.velocity = new Vector2(0, launcherLowerVelocity);
            }
            else
            {
                rigidBody.velocity = new Vector2(0, 0);
            }

            if (transform.position.y < (startPosition.y - maxLauncherDelta))
            {
                rigidBody.velocity = new Vector2(0, launchVelocity);
                launching = false;
            }
        }

        if (transform.position.y > startPosition.y)
        {
            rigidBody.velocity = new Vector2(0, 0);
            transform.position = startPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pinball")
        {
            launching = true;
        }
    }
}
