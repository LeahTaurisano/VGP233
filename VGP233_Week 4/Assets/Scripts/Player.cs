using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D playerRB;
    private bool grounded = false;
    private bool canDoubleJump = true;

    private void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), playerRB.velocity.y);
        }
        else
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && (grounded || canDoubleJump))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            //playerRB.AddForce(new Vector2(0, jumpForce));
            if (grounded)
            {
                grounded = false;
            }
            else
            {
                canDoubleJump = false;
            }
        }
        //Debug.Log(Input.GetAxis("Horizontal"));
        
        //if (Input.GetKey(KeyCode.D))
        //{
        //    //transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        //    playerRB.velocity = new Vector2(moveSpeed, playerRB.velocity.y);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    //transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        //    playerRB.velocity = new Vector2(-moveSpeed, playerRB.velocity.y);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            grounded = true;
            canDoubleJump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            grounded = false;
        }
    }
}
