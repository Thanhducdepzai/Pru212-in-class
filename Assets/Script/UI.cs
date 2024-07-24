using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI overText;

    private float time = 60f;
    public int score;
    private bool isPaused = false;
    public static UI instance;
    public bool isGameEnded = false;  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of UI detected");
        }
    }

    void Update()
    {
        if (isGameEnded) return;  

        if (!isPaused)
        {
            time -= Time.deltaTime;

            if (time > 0)
            {
                timeText.text = "Time: " + time.ToString("#,#");
            }
            else
            {
                time = 0;
                Time.timeScale = 0;
                overText.text = "Time out great job";

                float playTime = 60f - time;
                PlayerPrefs.SetInt("PlayerScore", score);
                PlayerPrefs.SetFloat("PlayTime", playTime);
                PlayerPrefs.Save();

                SceneManager.LoadScene("EndScene");
            }
        }
    }

    public void addScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString("#,#");
        }
        else
        {
            Debug.LogError("ScoreText is not assigned");
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void EndGame()
    {
        isGameEnded = true;  
    }
}
