using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool isGameOver = false;
    private bool isGameClear = false;

    [Header("UI")]
    public GameObject scoreBoardWindow;
    public TextMeshProUGUI scoretxt;
    public GameObject retryBtn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0f;
            ScoreBoard("Game Over");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            retryBtn.SetActive(true);
        }
    }

    public void GameClear()
    {
        if (!isGameClear)
        {
            isGameClear = true;
            Time.timeScale = 0f;
            ScoreBoard("Game Clear!");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            retryBtn.SetActive(true);
        }
    }

    private void ScoreBoard(string message)
    {
        scoreBoardWindow.SetActive(true);

        if (scoretxt != null)
        {
            scoretxt.text = message + "\n" + "\n현재점수 : " + ScoreManager.Instance.score;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        scoreBoardWindow.SetActive(false);
        retryBtn.SetActive(false);

        isGameOver = false;
        isGameClear = false;

        SceneManager.LoadScene("MainScene");
    }
}
