using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class QuitGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
