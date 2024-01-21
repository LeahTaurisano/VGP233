using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.gray;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pinball" && !BallManager.IsMultiballActive())
        {
            if (sprite.color == Color.gray)
            {
                SetLight(true);
            }
            else
            {
                SetLight(false);
            }
        }
    }

    public void SetLight(bool active)
    {
        if (active)
        {
            sprite.color = Color.yellow;
        }
        else
        {
            sprite.color = Color.gray;
        }
        isActive = active;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
