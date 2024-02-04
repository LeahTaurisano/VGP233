using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollect" || collision.tag == "PlayerAssist")
        {
            Player playerComponent = collision.GetComponent<Player>();
            playerComponent.RespawnPlayer();
        }
    }
}
