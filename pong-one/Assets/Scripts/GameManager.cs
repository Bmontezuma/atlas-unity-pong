using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int WinningScore = 11;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI resultText;
    public GameObject endGamePanel;

    private int leftScore = 0;
    private int rightScore = 0;

    void Start()
    {
        UpdateScoreUI();
        endGamePanel.SetActive(false);
    }

    public void AddScore(bool isLeftPlayer)
    {
        if (isLeftPlayer)
        {
            leftScore++;
        }
        else
        {
            rightScore++;
        }
        CheckForWinner();
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    private void CheckForWinner()
    {
        if (leftScore >= WinningScore)
        {
            DeclareWinner(true);
        }
        else if (rightScore >= WinningScore)
        {
            DeclareWinner(false);
        }
    }

    private void DeclareWinner(bool isLeftPlayer)
    {
        endGamePanel.SetActive(true);
        if (isLeftPlayer)
        {
            resultText.text = "Player One Wins!";
        }
        else
        {
            resultText.text = "Player Two Wins!";
        }
        Time.timeScale = 0; // Stop the game
    }

    public void RestartGame()
    {
        leftScore = 0;
        rightScore = 0;
        Time.timeScale = 1; // Resume the game
        endGamePanel.SetActive(false);
        UpdateScoreUI();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}