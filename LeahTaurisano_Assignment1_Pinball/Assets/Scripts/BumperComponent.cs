using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperComponent : MonoBehaviour
{
    [SerializeField] private float pointValue;
    [SerializeField] private float multiValue;


    private float bounceTimerMax = 0.05f;
    private float bounceTimer = 0.05f;
    private SpriteRenderer sprite;
    private Vector3 startingScale;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        startingScale = transform.localScale;
        sprite.color = Color.red;
    }
    private void Update()
    {
        if (transform.localScale != startingScale)
        {
            bounceTimer -= Time.deltaTime;
            if (bounceTimer <= 0.0f)
            {
                transform.localScale = startingScale;
                bounceTimer = bounceTimerMax;
            }
        }
        if (BallManager.GetGameOver())
        {
            sprite.color = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale = transform.localScale * 0.9f;
        ScoreManager.IncreaseScore(pointValue);
        ScoreManager.IncreaseMultiplier(multiValue);
        if (collision.gameObject.tag == "Pinball")
        {
            if (sprite.color == Color.red)
            {
                sprite.color = Color.yellow;
            }
            else if (sprite.color == Color.yellow)
            {
                sprite.color = Color.green;
            }
            else if (sprite.color == Color.green)
            {
                sprite.color = Color.blue;
            }
            else if (sprite.color == Color.blue)
            {
                sprite.color = Color.magenta;
            }
            else if (sprite.color == Color.magenta)
            {
                sprite.color = Color.red;
            }
        }
    }
}
