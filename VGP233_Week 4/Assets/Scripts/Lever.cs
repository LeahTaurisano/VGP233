using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite leverUp;
    [SerializeField] private Sprite leverDown;

    private bool isFlipped = false;
    private bool isClose = false;
    private SpriteRenderer leverSprite;

    void Start()
    {
        leverSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isClose && Input.GetKeyDown(KeyCode.Return))
        {
            FlipLever();
        }       
    }

    public void FlipLever()
    {
        isFlipped = !isFlipped;
        if (isFlipped)
        {
            leverSprite.sprite = leverDown;
        }
        else
        {
            leverSprite.sprite = leverUp;
        }
        FlipBlocks();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAssist")
        {
            isClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAssist")
        {
            isClose = false;
        }
    }

    private void FlipBlocks()
    {
        foreach (Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
    }
}
