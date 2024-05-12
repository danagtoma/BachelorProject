using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowHomeScene : MonoBehaviour
{
    public int homeScene;

    public void StartHomeScene()
    {
        SceneManager.LoadScene(homeScene);
    }
}
