using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollect")
        {
            GameManager.Instance.CollectGem();
            Destroy(gameObject);
        }
    }
}
