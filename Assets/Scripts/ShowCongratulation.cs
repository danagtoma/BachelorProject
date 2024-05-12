using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowCongratulation : MonoBehaviour
{
    public int congratulationScene;
    public GameObject cavity;
    public RestartGame restartGame;

    private void Update()
    {
        if (cavity.transform.localScale == Vector3.one)
        {
            StartCongratulationScene();
        }
    }
    public void StartCongratulationScene()
    {
         SceneManager.LoadScene(congratulationScene);
         restartGame.ResetTargetScale();
    }
}
