using System;
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
    [SerializeField] private Player otherPlayer;

    private Rigidbody2D playerRB;
    private bool grounded = false;
    private bool canDoubleJump = true;
    private Vector3 spawnPosition;
    private Animator animator;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
        animator = gameObject.GetComponent<Animator>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveDirection = Input.GetAxis(axis);
        if (moveDirection < 0)
        {
            playerSprite.flipX = true;
        }
        else if (moveDirection > 0)
        {
            playerSprite.flipX = false;
        }
        animator.SetFloat("MoveSpeed", Math.Abs(moveDirection));
        if (Input.GetKey(left) || Input.GetKey(right))
        {
            playerRB.velocity = new Vector2(moveSpeed * moveDirection, playerRB.velocity.y);
        }
        else
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }
        if (Input.GetKeyDown(up) && (grounded || canDoubleJump))
        {
            animator.SetBool("IsGrounded", false);
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
        if (playerRB.velocity.y > -0.5f)
        {
            animator.SetBool("IsFalling", false);
        }
        else if (playerRB.velocity.y < -1.0f)
        {
            animator.SetBool("IsFalling", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform" || collision.tag == "PlayerCollect" || collision.tag == "PlayerAssist")
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsGrounded", true);
            grounded = true;
            canDoubleJump = true;
        }
        if (collision.tag == "Killzone")
        {
            RespawnPlayer();
            otherPlayer.RespawnPlayer();
        }
        if (collision.tag == "Checkpoint")
        {
            Checkpoint respawnPoint = collision.GetComponent<Checkpoint>();
            if (!respawnPoint.GetHasBeenTriggered())
            {
                Vector3 offset = new Vector3(playerSprite.bounds.size.x, 0, 0);
                SetSpawnPosition(respawnPoint.GetRespawnPosition());
                otherPlayer.SetSpawnPosition(respawnPoint.GetRespawnPosition() + offset);
                respawnPoint.SetHasBeenTriggered(true);
            }
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
        playerRB.velocity = Vector2.zero;
    }
}
