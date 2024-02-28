using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 speed;
    [SerializeField] private float moveTimer;

    private Rigidbody rb;
    private float timer;
    private bool forward = true;
    private bool waiting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!waiting)
        {
            if (timer < moveTimer && forward)
            {
                rb.velocity = speed;
                timer += Time.deltaTime;
            }
            else if (timer < moveTimer && !forward)
            {
                rb.velocity = -speed;
                timer += Time.deltaTime;
            }
            else
            {
                rb.velocity = Vector3.zero;
                timer = -1.0f;
                waiting = true;
                forward = !forward;
            }
        }
        else
        {
            timer += Time.deltaTime;
            rb.velocity = Vector3.zero;
            if (timer > 0)
            {
                waiting = false;
            }
        }
    }
}
