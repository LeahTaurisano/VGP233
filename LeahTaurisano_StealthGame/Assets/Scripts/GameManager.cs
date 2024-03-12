using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject textCanvas;
    [SerializeField] TextMeshProUGUI text;
    public static GameManager Instance;
    public static int documentsFound = 0;
    public static int documentsCount = 5;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        textCanvas.SetActive(true);
        text.text = "Game Over!";
        Time.timeScale = 0;
    }

    public void Victory()
    {
        text.text = "Victory!";
        Time.timeScale = 0;
    }

    public bool VictoryCheck()
    {
        if (documentsFound >= documentsCount)
        {
            return true;
        }
        return false;
    }

    public void FindDocument()
    {
        documentsFound++;
    }
}
