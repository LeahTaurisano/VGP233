using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] Canvas UI;
    [SerializeField] TextMeshProUGUI text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollect" || collision.tag == "PlayerAssist")
        {
            UI.enabled = true;
            if (GemManager.gemCount >= GemManager.maxGems)
            {
                text.text = "Victory!";
                Time.timeScale = 0;
            }
            else
            {
                text.text = "Collect All Gems to Finish the Level";
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollect" || collision.tag == "PlayerAssist")
        {
            UI.enabled = false;
        }
    }
}
