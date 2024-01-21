using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float maxLauncherDelta;
    [SerializeField] private float launcherLowerVelocity;
    [SerializeField] private float launchVelocity;

    private Vector3 startPosition;
    private Rigidbody2D rigidBody;
    private float timeHeld;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.position.y > (startPosition.y - maxLauncherDelta))
            {
                timeHeld += Time.deltaTime;
                rigidBody.velocity = new Vector2(0, launcherLowerVelocity);
            }
            else
            {
                rigidBody.velocity = new Vector2(0, 0);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && transform.position.y < startPosition.y)
        {
            rigidBody.velocity = new Vector2(0, launchVelocity * timeHeld);
            timeHeld = 0.0f;
        }
        if (transform.position.y > startPosition.y)
        {
            rigidBody.velocity = new Vector2(0, 0);
            transform.position = startPosition;
        }
    }
}
