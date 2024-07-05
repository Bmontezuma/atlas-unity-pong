using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int WinningScore = 11; // Score needed to win the game
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public EndGameManager endGameManager; // Reference to EndGameManager
    public AudioSource victoryAudioSource; // Reference to AudioSource for victory music

    private int leftScore = 0;
    private int rightScore = 0;

    void Start()
    {
        UpdateScoreUI(); // Initialize the score UI
    }

    public void AddScore(bool isLeftPlayer)
    {
        // Increment the score of the appropriate player
        if (isLeftPlayer)
        {
            leftScore++;
        }
        else
        {
            rightScore++;
        }
        CheckForWinner(); // Check if there is a winner after updating the score
        UpdateScoreUI(); // Update the score display
    }

    private void UpdateScoreUI()
    {
        // Update the score text elements with the current scores
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    private void CheckForWinner()
    {
        // Determine if either player has reached the winning score
        if (leftScore >= WinningScore)
        {
            DeclareWinner(true); // Left player wins
        }
        else if (rightScore >= WinningScore)
        {
            DeclareWinner(false); // Right player wins
        }
    }

    private void DeclareWinner(bool isLeftPlayer)
    {
        // Display the end game screen and play victory music
        Time.timeScale = 0; // Stop the game
        string resultMessage = isLeftPlayer ? "Player One Wins!" : "Player Two Wins!";
        endGameManager.ShowEndGameScreen(resultMessage);
        PlayVictoryMusic(); // Play victory music
    }

    private void PlayVictoryMusic()
    {
        // Play the victory music if the AudioSource and clip are set
        if (victoryAudioSource != null && victoryAudioSource.clip != null)
        {
            victoryAudioSource.Play();
        }
    }
}
