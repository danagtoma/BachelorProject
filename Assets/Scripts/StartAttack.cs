using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartAttack : MonoBehaviour
{
    public Canvas hideCanvas;
    private bool isCanvasVisible = false;
    public BacteriaSpawner spawner;
    public CountdownManager countdownManager;

    public void OnPointerClick()
    {
        hideCanvas.gameObject.SetActive(isCanvasVisible);
        isCanvasVisible = !isCanvasVisible;
        spawner.StartAttackFunction();
        countdownManager.StartCountdown(60);
    }

    public void RestartAttack()
    {
        isCanvasVisible = false;
        hideCanvas.gameObject.SetActive(true);
    } 
}

