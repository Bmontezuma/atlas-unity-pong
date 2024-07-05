using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI resultText;
    public Button replayButton;
    public Button mainMenuButton;

    void Start()
    {
        // Initially hide the end game panel
        endGamePanel.SetActive(false);

        // Add button listeners
        replayButton.onClick.AddListener(OnReplayButtonClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }

    public void ShowEndGameScreen(string result)
    {
        endGamePanel.SetActive(true);
        resultText.text = result;

        // Disable main gameplay elements
        GameObject.FindGameObjectWithTag("PlayerPaddle").SetActive(false);
        GameObject.FindGameObjectWithTag("AIPaddle").SetActive(false);
        GameObject.FindGameObjectWithTag("Ball").SetActive(false);
    }

    void OnReplayButtonClicked()
    {
        // Reload the current scene to replay the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnMainMenuButtonClicked()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
