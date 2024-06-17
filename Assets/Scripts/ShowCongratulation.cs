using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowCongratulation : MonoBehaviour
{
    public int congratulationScene;
    public GameObject cavity;
    public RestartGame restartGame;
    public int waitTime = 5;

    private void Update()
    {
        if (cavity.transform.localScale == Vector3.one)
        {
            StartCoroutine(StartCongratulationSceneWithDelay());
        }
    }

    public void StartCongratulationScene()
    {
         
         SceneManager.LoadScene(congratulationScene);
         restartGame.ResetTargetScale();
    }
    private IEnumerator StartCongratulationSceneWithDelay()
    {
        yield return new WaitForSeconds(waitTime);
        StartCongratulationScene();
    }

}
