using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieClick : MonoBehaviour
{
    [SerializeField] private int playerScore;
    [SerializeField] private int pointsPerClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        playerScore += pointsPerClick;
        if (((playerScore % 100) / pointsPerClick) == 0)
        {
            pointsPerClick++;
        }
    }
}
