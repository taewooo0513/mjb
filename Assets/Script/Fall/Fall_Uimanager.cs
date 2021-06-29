using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fall_Uimanager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameoverPanel;
    private int score;
    private float curTime;

    // Start is called before the first frame update
    void Start()
    {
        score = Fall_Gamemanager.score;
        scoreText.text = "" + score;

        pausePanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (score != Fall_Gamemanager.score)
        {
            score = Fall_Gamemanager.score;
            scoreText.text = "" + score;
        }

        if(Fall_Gamemanager.isGameOver)
        {
            if (!gameoverPanel.activeSelf)
            {
                gameoverPanel.SetActive(true);
            }

            Time.timeScale = 0;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Fall");
    }
}
