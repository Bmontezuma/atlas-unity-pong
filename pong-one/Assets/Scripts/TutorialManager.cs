using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialSteps;
    private int currentStep = 0;

    public Button nextButton;
    public Button backButton;

    void Start()
    {
        // Initialize the first step
        UpdateTutorialStep();

        // Add listeners to buttons
        nextButton.onClick.AddListener(NextStep);
        backButton.onClick.AddListener(PreviousStep);
    }

    void UpdateTutorialStep()
    {
        for (int i = 0; i < tutorialSteps.Length; i++)
        {
            tutorialSteps[i].SetActive(i == currentStep);
        }

        // Enable/disable buttons based on the current step
        backButton.gameObject.SetActive(currentStep > 0);
        nextButton.gameObject.SetActive(currentStep < tutorialSteps.Length - 1);
    }

    public void NextStep()
    {
        if (currentStep < tutorialSteps.Length - 1)
        {
            currentStep++;
            UpdateTutorialStep();
        }
        else
        {
            EndTutorial();
        }
    }

    public void PreviousStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            UpdateTutorialStep();
        }
    }

    void EndTutorial()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
