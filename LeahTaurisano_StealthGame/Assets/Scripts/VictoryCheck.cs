using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VictoryCheck : MonoBehaviour
{
    [SerializeField] GameObject textCanvas;
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        textCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textCanvas.SetActive(true);
            if (GameManager.Instance.VictoryCheck())
            {
                text.text = "Victory!";
                GameManager.Instance.GameOver();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textCanvas.SetActive(false);
        }
    }
}
