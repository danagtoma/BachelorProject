using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToogleArScene : MonoBehaviour
{
    public Toggle toggle; 
    public int sceneToLoad; 
    public int sceneToLoadOnToggleOff; 
    private const string ToggleStateKey = "ToggleState"; 

    void Start()
    {
        if (toggle != null)
        {
            bool savedState = PlayerPrefs.GetInt(ToggleStateKey, 0) == 1;
            toggle.isOn = savedState;
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }
        else
        {
            Debug.LogError("Toggle is not assigned.");
        }
    }

    void OnToggleValueChanged(bool isOn)
    {
        PlayerPrefs.SetInt(ToggleStateKey, isOn ? 1 : 0);
        PlayerPrefs.Save();

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
