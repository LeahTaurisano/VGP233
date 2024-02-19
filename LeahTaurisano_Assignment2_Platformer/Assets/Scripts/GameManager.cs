using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int maxGems;
    private int gemCount = 0;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        GameObject[] gems = GameObject.FindGameObjectsWithTag("Gem");
        maxGems = gems.Length;
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
