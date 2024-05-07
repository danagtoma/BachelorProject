using UnityEngine;

public class FillCavity : MonoBehaviour
{
    public float GrowDuration = 5f;  

    public Vector3 TargetScale = Vector3.one * 1f;

    private Vector3 startScale;
    
    private float t = 0;
    
    private bool isGrowing = false;

    public GameObject cavityBlack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("material"))  
        {
            isGrowing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("material"))  
        {
            isGrowing = false;
        }
    }

    void OnEnable()
    {
        startScale = transform.localScale;
        t = 0;
        isGrowing = false;
    }

    void Update()
    {
        if (isGrowing && cavityBlack.transform.localScale.x < 0.55f)
        {
            
            t += Time.deltaTime / GrowDuration;

            
            Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);

            
            transform.localScale = newScale;

            
            if (t >= 1)
            {
                isGrowing = false; 
                enabled = false;  
            }
        }
    }

    
    public void ResetGrowing()
    {
        enabled = true;  
        t = 0;  
        transform.localScale = startScale;  
        isGrowing = false;  
    }
}
