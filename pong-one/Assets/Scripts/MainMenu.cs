using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to start the game
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with the name of your game scene
    }

    // Method to load the tutorial
    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene"); // Replace "TutorialScene" with the name of your tutorial scene
    }

    // Method to load the settings menu
    public void LoadSettings()
    {
        SceneManager.LoadScene("OptionsMenu"); // Replace with the settings scene name
    }

    // Method to load the credits
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game Button Pressed");
        Application.Quit();
    }
}
