using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public RectTransform creditsTextTransform;
    public float scrollSpeed = 30f; // Adjust this value for faster or slower scrolling
    public AudioSource backgroundMusicAudioSource; // Reference to the Background Music AudioSource component
    public AudioSource laughAudioSource; // Reference to the Laugh AudioSource component

    private bool musicStopped = false; // To ensure music is stopped only once

    void Start()
    {
        // Set the initial position off-screen at the bottom
        creditsTextTransform.anchoredPosition = new Vector2(0, -Screen.height);

        // Play background music
        backgroundMusicAudioSource.Play();
    }

    void Update()
    {
        // Scroll the credits up
        creditsTextTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Check if the credits have scrolled completely off the screen
        if (creditsTextTransform.anchoredPosition.y >= Screen.height + creditsTextTransform.rect.height)
        {
            if (!musicStopped)
            {
                // Stop background music
                backgroundMusicAudioSource.Stop();
                musicStopped = true;

                // Invoke the laugh sound after a delay
                Invoke("PlayLaughSound", 2f); // Adjust the delay as needed
            }
        }
    }

    void PlayLaughSound()
    {
        laughAudioSource.Play();
        // Load the MainMenu scene after the laugh sound has finished playing
        Invoke("LoadMainMenu", laughAudioSource.clip.length);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
