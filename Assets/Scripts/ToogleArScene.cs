using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToogleArScene : MonoBehaviour
{
    public Toggle toggle; // Reference to the Toggle component
    public int sceneToLoad; // Name of the scene to switch to when toggled on
    public int sceneToLoadOnToggleOff; // Name of the scene to switch to when toggled off
    private const string ToggleStateKey = "ToggleState"; // Key to save toggle state

    void Start()
    {
        if (toggle != null)
        {
            // Load the saved toggle state
            bool savedState = PlayerPrefs.GetInt(ToggleStateKey, 0) == 1;
            toggle.isOn = savedState;
            // Add listener to handle value changes
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }
        else
        {
            Debug.LogError("Toggle is not assigned.");
        }
    }

    void OnToggleValueChanged(bool isOn)
    {
        // Save the toggle state
        PlayerPrefs.SetInt(ToggleStateKey, isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Load the appropriate scene based on the toggle state
        if (isOn)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            SceneManager.LoadScene(sceneToLoadOnToggleOff);
        }
    }

    void OnDestroy()
    {
        if (toggle != null)
        {
            toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    }
}
