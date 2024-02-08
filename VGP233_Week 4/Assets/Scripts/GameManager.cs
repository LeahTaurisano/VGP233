using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int maxGems = 1;
    public static int gemCount = 0;

    void Start()
    {
        if (Instance == null)
        {
            Instance = new GameManager();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
    }

    public void CollectGem()
    {
        ++gemCount;
    }

    public int GetGemCount()
    {
        return gemCount;
    }

    public int GetMaxGems()
    {
        return maxGems;
    }
}
