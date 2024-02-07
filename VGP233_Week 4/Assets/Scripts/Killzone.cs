using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    [SerializeField] Player playerCollect;
    [SerializeField] Player playerAssist;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollect" || collision.tag == "PlayerAssist")
        {
            playerCollect.RespawnPlayer();
            playerAssist.RespawnPlayer();
        }
    }
}
