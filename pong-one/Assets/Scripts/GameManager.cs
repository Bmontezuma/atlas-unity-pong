using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public int winningScore = 11;

    private int leftScore = 0;
    private int rightScore = 0;

    public void AddScore(string playerTag)
    {
        if (playerTag == "LeftPlayer")
        {
            leftScore++;
            leftScoreText.text = leftScore.ToString();
            if (leftScore >= winningScore)
            {
                EndGame("Left Player Wins!");
            }
        }
        else if (playerTag == "RightPlayer")
        {
            rightScore++;
            rightScoreText.text = rightScore.ToString();
            if (rightScore >= winningScore)
            {
                EndGame("Right Player Wins!");
            }
        }
    }

    private void EndGame(string message)
    {
        Debug.Log(message);
        // Display victory/defeat message
        FindObjectOfType<EndGameManager>().ShowEndGameScreen(message);
        FindObjectOfType<AudioSource>().Play(); // Play victory music
    }
}
