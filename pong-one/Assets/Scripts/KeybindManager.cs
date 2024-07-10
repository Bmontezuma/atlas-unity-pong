using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeybindManager : MonoBehaviour
{
    public Button upKeyButton;
    public Button downKeyButton;
    private KeyCode newKey;

    void Start()
    {
        upKeyButton.onClick.AddListener(() => StartKeyAssignment("upKey"));
        downKeyButton.onClick.AddListener(() => StartKeyAssignment("downKey"));
    }

    void StartKeyAssignment(string keyName)
    {
        StartCoroutine(AssignKey(keyName));
    }

    IEnumerator AssignKey(string keyName)
    {
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                newKey = keyCode;
                break;
            }
        }

        if (keyName == "upKey")
        {
            PlayerPrefs.SetString("UpKey", newKey.ToString());
        }
        else if (keyName == "downKey")
        {
            PlayerPrefs.SetString("DownKey", newKey.ToString());
        }
    }
}
