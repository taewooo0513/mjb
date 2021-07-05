using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Common_UiManager : MonoBehaviour
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
        if (scoreText.text != score.ToString()) //점수 텍스트 업데이트
        {
            scoreText.text = "" + score;
        }

        if (isGameOver) //게임 오버 처리
        {
            if (!gameoverPanel.activeSelf)
            {
                gameoverPanel.SetActive(true);
            }

            Time.timeScale = 0;
        }
    }

    public void Pause() //게임 정지
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Continue() //게임 재개
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnMenu() //메뉴로 돌아가기
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart() //게임 재시작
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
