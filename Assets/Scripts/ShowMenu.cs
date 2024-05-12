using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMenu : MonoBehaviour
{
    public Canvas showMenuCanvas;

    private bool isCanvasVisible = true;

    public void OnPointerClick()
    {
        isCanvasVisible = !isCanvasVisible;
        showMenuCanvas.gameObject.SetActive(isCanvasVisible);
    }
}
