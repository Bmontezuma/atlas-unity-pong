using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections.Generic;

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
        Debug.Log("OptionsMenu Start");

        // Load and apply saved settings
        LoadSettings();

        // Add listeners to UI components if they are not null
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(SetVolume);
        else
            Debug.LogError("Volume Slider is not assigned in the Inspector");

        if (saveButton != null)
            saveButton.onClick.AddListener(SaveSettings);
        else
            Debug.LogError("Save Button is not assigned in the Inspector");

        if (backButton != null)
            backButton.onClick.AddListener(BackToMainMenu);
        else
            Debug.LogError("Back Button is not assigned in the Inspector");

        // Initialize resolution dropdown
        InitializeResolutionDropdown();
    }

    void LoadSettings()
    {
        Debug.Log("LoadSettings called");

        if (volumeSlider != null)
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
        else
            Debug.LogError("Volume Slider is not assigned in the Inspector");

        if (graphicsDropdown != null)
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);
        else
            Debug.LogError("Graphics Dropdown is not assigned in the Inspector");

        if (fullscreenToggle != null)
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        else
            Debug.LogError("Fullscreen Toggle is not assigned in the Inspector");

        ApplySettings();
    }

    void ApplySettings()
    {
        Debug.Log("ApplySettings called");

        if (volumeSlider != null && audioMixer != null)
            audioMixer.SetFloat("Volume", Mathf.Log10(volumeSlider.value) * 20);
        else
            Debug.LogError("Volume Slider or Audio Mixer is not assigned in the Inspector");

        if (graphicsDropdown != null)
            QualitySettings.SetQualityLevel(graphicsDropdown.value);
        else
            Debug.LogError("Graphics Dropdown is not assigned in the Inspector");

        if (fullscreenToggle != null)
            Screen.fullScreen = fullscreenToggle.isOn;
        else
            Debug.LogError("Fullscreen Toggle is not assigned in the Inspector");
    }

    public void SaveSettings()
    {
        Debug.Log("SaveSettings called");

        if (volumeSlider != null)
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        else
            Debug.LogError("Volume Slider is not assigned in the Inspector");

        if (graphicsDropdown != null)
            PlayerPrefs.SetInt("GraphicsQuality", graphicsDropdown.value);
        else
            Debug.LogError("Graphics Dropdown is not assigned in the Inspector");

        if (fullscreenToggle != null)
            PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        else
            Debug.LogError("Fullscreen Toggle is not assigned in the Inspector");

        ApplySettings();

        // Optional: Show a confirmation message
        Debug.Log("Settings Saved!");
    }

    public void BackToMainMenu()
    {
        Debug.Log("BackToMainMenu called");
        SceneManager.LoadScene("MainMenu");
    }

    void SetVolume(float volume)
    {
        if (audioMixer != null)
            audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        else
            Debug.LogError("Audio Mixer is not assigned in the Inspector");
    }

    void InitializeResolutionDropdown()
    {
        resolutions = Screen.resolutions;
        if (resolutionDropdown == null)
        {
            Debug.LogError("Resolution Dropdown is not assigned in the Inspector");
            return;
        }

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
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutionIndex >= 0 && resolutionIndex < resolutions.Length)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        else
        {
            Debug.LogError("Invalid resolution index");
        }
    }

    public void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreen", isFullScreen ? 1 : 0);
    }
}
