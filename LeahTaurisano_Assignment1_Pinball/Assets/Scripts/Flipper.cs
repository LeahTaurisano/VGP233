using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float flipSpeed;
    [SerializeField] private float rotationAngle;
    [SerializeField] private bool RFlipper;

    private Rigidbody2D rigidBody;
    private Quaternion minRotation, maxRotation;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        maxRotation = transform.rotation;
        transform.Rotate(0, 0, -rotationAngle);
        minRotation = transform.rotation;
        transform.Rotate(0, 0, rotationAngle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition;

        if (RFlipper)
        {
            if (transform.rotation.z < minRotation.z)
            {
                rigidBody.totalTorque = 0.0f;
                rigidBody.freezeRotation = true;
                transform.rotation = minRotation;
            }
            else if (transform.rotation.z > maxRotation.z)
            {
                rigidBody.totalTorque = 0.0f;
                rigidBody.freezeRotation = true;
                transform.rotation = maxRotation;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                FlipUp(-flipSpeed);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                FlipDown(flipSpeed);
            }
        }
        else
        {
            if (transform.rotation.z > minRotation.z)
            {
                rigidBody.totalTorque = 0.0f;
                rigidBody.freezeRotation = true;
                transform.rotation = minRotation;
            }
            else if (transform.rotation.z < maxRotation.z)
            {
                rigidBody.totalTorque = 0.0f;
                rigidBody.freezeRotation = true;
                transform.rotation = maxRotation;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                FlipUp(-flipSpeed);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                FlipDown(flipSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pinball")
        {
            if (!BallManager.IsMultiballActive())
            {
                ScoreManager.ResetMultiplier();
            }
        }
    }

    void FlipUp(float torque)
    {
        rigidBody.freezeRotation = false;
        rigidBody.totalTorque = 0.0f;
        rigidBody.AddTorque(torque);
    }
    void FlipDown(float angle)
    {
        rigidBody.freezeRotation = false;
        rigidBody.totalTorque = 0.0f;
        transform.Rotate(0, 0, angle);
    }
}
