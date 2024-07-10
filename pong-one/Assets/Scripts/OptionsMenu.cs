using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections.Generic; // Add this line

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Dropdown graphicsDropdown;
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Button saveButton;
    public Button backButton;
    public AudioMixer audioMixer;

    private Resolution[] resolutions;

    void Start()
    {
        // Load and apply saved settings
        LoadSettings();

        // Add listeners to UI components
        volumeSlider.onValueChanged.AddListener(SetVolume);
        saveButton.onClick.AddListener(SaveSettings);
        backButton.onClick.AddListener(BackToMainMenu);

        // Initialize resolution dropdown
        InitializeResolutionDropdown();
    }

    void LoadSettings()
    {
        // Load saved settings using PlayerPrefs
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
        graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        // Apply loaded settings
        ApplySettings();
    }

    void ApplySettings()
    {
        // Apply settings based on UI component values
        audioMixer.SetFloat("Volume", Mathf.Log10(volumeSlider.value) * 20);
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void SaveSettings()
    {
        // Save settings using PlayerPrefs
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetInt("GraphicsQuality", graphicsDropdown.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);

        // Apply settings
        ApplySettings();

        // Optional: Show a confirmation message
        Debug.Log("Settings Saved!");
    }

    public void BackToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    void InitializeResolutionDropdown()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreen", isFullScreen ? 1 : 0);
    }
}
