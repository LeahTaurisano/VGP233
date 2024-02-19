using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    private Rigidbody2D backgroundRB;
    private SpriteRenderer backgroundSprite;
    private float distanceTraveled;
    private float startPosX;

    private void Start()
    {
        backgroundRB = gameObject.GetComponent<Rigidbody2D>();
        backgroundSprite = gameObject.GetComponent<SpriteRenderer>();
        startPosX = transform.position.x;
    }

    private void LateUpdate()
    {
        backgroundRB.velocity = new Vector2(gameCamera.velocity.x / 2, 0);
        distanceTraveled = transform.position.x - startPosX;
        if (distanceTraveled >= backgroundSprite.bounds.size.x)
        {
            transform.position = new Vector3(transform.position.x + backgroundSprite.bounds.size.x, transform.position.y, transform.position.z);
            distanceTraveled = 0.0f;
            startPosX = transform.position.x;
        }
        else if (distanceTraveled <= -backgroundSprite.bounds.size.x)
        {
            transform.position = new Vector3(transform.position.x - backgroundSprite.bounds.size.x, transform.position.y, transform.position.z);
            distanceTraveled = 0.0f;
            startPosX = transform.position.x;
        }
    }
}
