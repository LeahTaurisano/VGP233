using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI endText;

    public static GameManager Instance;

    private float time = 0;
    private bool isPaused = false;

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
    }

    private void LateUpdate()
    {
        time += Time.deltaTime;
        timerText.text = "Time: " + (int)time;
    }

    public void WinLevel()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        endText.text += (int)time + " seconds!";
        isPaused = true;
    }

    public bool GetPaused()
    {
        return isPaused;
    }
}
