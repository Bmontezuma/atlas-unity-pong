using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        GameObject leftScore = CreateScoreObject("LeftScore", new Vector3(-100, -100, 0), canvas.transform);
        // Create RightScore GameObject
        GameObject rightScore = CreateScoreObject("RightScore", new Vector3(100, -100, 0), canvas.transform);
    }

    GameObject CreateScoreObject(string name, Vector3 position, Transform parent)
    {
        GameObject scoreObject = new GameObject(name);
        scoreObject.transform.SetParent(parent);
        scoreObject.transform.localPosition = position;

        TextMeshProUGUI textComponent = CreateTextComponent(scoreObject);
        textComponent.text = "0";

        return scoreObject;
    }

    TextMeshProUGUI CreateTextComponent(GameObject parent)
    {
        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(parent.transform);

        TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
        RectTransform rectTransform = textComponent.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(150, 150);
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);
        rectTransform.localPosition = Vector3.zero;

        textComponent.enableAutoSizing = true;
        textComponent.fontSizeMin = 18;
        textComponent.fontSizeMax = 250;

        return textComponent;
    }
}