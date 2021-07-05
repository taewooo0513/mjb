using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fall_Uimanager : MonoBehaviour
{
    [HideInInspector] public static int score;
    [HideInInspector] public static bool isGameOver;

    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameoverPanel;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        scoreText.text = "" + score;

        isGameOver = false;

        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
        }
        if (gameoverPanel.activeSelf)
        {
            gameoverPanel.SetActive(false);
        }
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText.text != score.ToString())
        {
            scoreText.text = "" + score;
        }

        if(isGameOver)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
