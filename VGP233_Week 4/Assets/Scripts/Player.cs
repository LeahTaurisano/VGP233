using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    //[SerializeField] private KeyCode down;
    [SerializeField] private string axis;

    private Rigidbody2D playerRB;
    private bool grounded = false;
    private bool canDoubleJump = true;
    private Vector3 spawnPosition;

    private void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(left) || Input.GetKey(right))
        {
            playerRB.velocity = new Vector2(moveSpeed * Input.GetAxis(axis), playerRB.velocity.y);
        }
        else
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }
        if (Input.GetKeyDown(up) && (grounded || canDoubleJump))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            if (grounded)
            {
                grounded = false;
            }
            else
            {
                canDoubleJump = false;
            }
        }
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
    
    public Vector3 GetSpawnPosition()
    {
        return spawnPosition;
    }

    public void SetSpawnPosition(Vector3 spawn)
    {
        spawnPosition = spawn;
    }

    public void RespawnPlayer()
    {
        transform.position = spawnPosition;
    }
}
