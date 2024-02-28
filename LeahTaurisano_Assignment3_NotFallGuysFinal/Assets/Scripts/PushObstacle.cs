using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;

    private bool waiting;
    private float timer = 0;
    private float waitTimer = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (waitTime > 0.0f)
        {
            waiting = true;
        }
    }

    void FixedUpdate()
    {
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > waitTime)
            {
                waitTimer = 0.0f;
                waiting = false;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer < 0.2f)
            {
                rb.velocity = new Vector3(speed, 0, 0);
            }
            else if (timer < 1.2f)
            {
                rb.velocity = Vector3.zero;
            }
            else if (timer < 1.4f)
            {
                rb.velocity = new Vector3(-speed, 0, 0);
            }
            else if (timer < 2.4f)
            {
                rb.velocity = Vector3.zero;
            }
            else
            {
                timer = 0.0f;
                waiting = true;
            }
        }
    }
}
