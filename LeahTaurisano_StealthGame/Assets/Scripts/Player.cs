using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float horizSpeed;
    [SerializeField] private float timeJumpCD = 20.0f;
    [SerializeField] private Material playerReady;
    [SerializeField] private Material playerCD;

    private Rigidbody rb;
    private List<Vector3> timePos;
    private float delayTimerMax = 5.0f;
    private float delayTimer = 0.0f;
    bool delayPassed = false;
    bool canTimeJump = false;
    private float timeJumpCDTimer = 0.0f;
    private MeshRenderer playerMesh;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMesh = GetComponent<MeshRenderer>();
        timePos = new List<Vector3>();
        timePos.Add(transform.position);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
        {
            float xInput = Input.GetAxis("Horizontal") * moveSpeed;
            float zInput = Input.GetAxis("Vertical") * moveSpeed;

            Vector3 localVelocity = new Vector3(xInput, rb.velocity.y, zInput);
            rb.velocity = transform.TransformDirection(localVelocity);
        }

        if (Input.GetMouseButton(1))
        {
            float horizontal = Input.GetAxis("Mouse X") * horizSpeed;

            transform.Rotate(0, horizontal, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canTimeJump)
        {
            transform.position = timePos[0];
            playerMesh.material = playerCD;
            canTimeJump = false;
            timeJumpCDTimer = 0.0f;
        }
        if (delayPassed)
        {
            timePos.RemoveAt(0);
            timePos.Add(transform.position);
        }
        if (!canTimeJump && delayPassed)
        {
            timeJumpCDTimer += Time.deltaTime;
            if (timeJumpCDTimer > timeJumpCD)
            {
                playerMesh.material = playerReady;
                canTimeJump = true;
            }
        }

        if (delayTimer > delayTimerMax && !delayPassed)
        {
            playerMesh.material = playerReady;
            canTimeJump = true;
            delayPassed = true;
            timePos.Add(transform.position);
        }
        else if (!delayPassed)
        {
            delayTimer += Time.deltaTime;
            timePos.Add(transform.position);
        }
    }

    private void Respawn(Vector3 respawnPos)
    {
        transform.position = respawnPos;
        rb.velocity = Vector3.zero;
    }
}
