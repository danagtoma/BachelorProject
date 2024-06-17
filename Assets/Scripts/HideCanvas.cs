using UnityEngine;
using System.Collections;

public class HideCanvas : MonoBehaviour
{
    public Canvas canvas; 
    public float delay = 10f;
    public GameObject mounth; 

    void Start()
    {
        StartCoroutine(HideCanvasForSeconds());
    }

    private IEnumerator HideCanvasForSeconds()
    {

        yield return new WaitForSeconds(delay);

        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
            mounth.SetActive(true);
        }
    }
}
