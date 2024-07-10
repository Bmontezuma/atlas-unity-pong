using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIScript : MonoBehaviour
{
    void Start()
    {
        // Ensure there is a Canvas in the scene
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObject = new GameObject("Canvas");
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
        }

        // Create LeftScore GameObject
        CreateScoreObject("LeftScore", new Vector3(-100, -100, 0), canvas.transform);
        // Create RightScore GameObject
        CreateScoreObject("RightScore", new Vector3(100, -100, 0), canvas.transform);
    }

    void CreateScoreObject(string name, Vector3 position, Transform parent)
    {
        // Create the parent GameObject
        GameObject scoreObject = new GameObject(name);
        scoreObject.transform.SetParent(parent);

        // Set the RectTransform properties
        RectTransform rectTransform = scoreObject.AddComponent<RectTransform>();
        rectTransform.localPosition = position;
        rectTransform.sizeDelta = new Vector2(150, 150);
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);

        // Add TextMeshPro component
        TextMeshProUGUI textComponent = scoreObject.AddComponent<TextMeshProUGUI>();
        textComponent.text = "0";
        textComponent.enableAutoSizing = true;
        textComponent.fontSizeMin = 18;
        textComponent.fontSizeMax = 250;
    }
}
