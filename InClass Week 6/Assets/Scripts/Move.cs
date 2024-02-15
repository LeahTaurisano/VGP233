using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        //float direction = Input.GetAxisRaw("Horizontal");
        //float moveDirection = Input.GetAxisRaw("Vertical");

        //transform.Translate(moveDirection * Vector3.forward * moveSpeed * Time.deltaTime);
        //transform.Rotate(0, direction * rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }
    }

    private void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(xMovement, rb.velocity.y, zMovement);

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            moveInput = Vector3.Normalize(moveInput);
        }

        //rb.MovePosition(transform.position + moveInput * Time.fixedDeltaTime * moveSpeed); //penetration
        rb.velocity = moveInput * moveSpeed; //no penetration
    }
}
