using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartAttack : MonoBehaviour
{
    public Canvas hideCanvas;
    private bool isCanvasVisible = false;
    public BacteriaSpawner spawner;

    public void OnPointerClick()
    {
        hideCanvas.gameObject.SetActive(isCanvasVisible);
        isCanvasVisible = !isCanvasVisible;
        spawner.StartAttackFunction();
    }
}
