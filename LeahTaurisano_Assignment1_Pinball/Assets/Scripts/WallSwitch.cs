using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float maxTimer = 0.5f;

    private float timer;

    private void Start()
    {
        timer = maxTimer;
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (timer < maxTimer)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0.0f)
        {
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            timer = maxTimer;
        }

        if (!BallManager.IsBallActive())
        {
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pinball")
        {
            timer -= Time.deltaTime;
        }
    }
}
