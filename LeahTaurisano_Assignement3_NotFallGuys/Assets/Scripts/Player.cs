using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float horizSpeed;
    [SerializeField] private float jumpSpeed;

    private Rigidbody rb;
    private bool isGrounded = true;
    private Vector3 respawnPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPos = transform.position;
    }

    void Update()
    {
        if (!GameManager.Instance.GetPaused())
        {
            if ((Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D)) &&
                isGrounded)
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

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
                isGrounded = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
        if (other.tag == "KillPlane")
        {
            Respawn(respawnPos);
        }
        if (other.tag == "Checkpoint")
        {
            respawnPos = other.transform.position;
        }
        if (other.tag == "Knockback")
        {
            isGrounded = false;
        }
    }

    private void Respawn(Vector3 respawnPos)
    {
        transform.position = respawnPos;
        rb.velocity = Vector3.zero;
    }
}
