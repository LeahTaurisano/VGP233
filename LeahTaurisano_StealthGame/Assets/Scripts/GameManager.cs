using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
