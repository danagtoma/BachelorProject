using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCavityRepair : MonoBehaviour
{
    public int cavityRepairScene;
     
    public void StartCavityRepairScene()
    {
        SceneManager.LoadScene(cavityRepairScene);
    }
}
