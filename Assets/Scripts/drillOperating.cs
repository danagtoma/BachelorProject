using UnityEngine;

public class DrillIntoSphere : MonoBehaviour
{

    public float ShrinkDuration = 5f;

    public Vector3 TargetScale = Vector3.one * .0001f;

    Vector3 startScale;
    
    float t = 0;

    private bool isDrilling = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("drill"))
        {
            isDrilling = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("drill"))
        {
            isDrilling = false;
        }
    }

    void OnEnable()
    {
        startScale = transform.localScale;
        t = 0;
        isDrilling = false;
    }

    void Update()
    {
        if (isDrilling)
        {
            
            t += Time.deltaTime / ShrinkDuration;
 
            Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);
            transform.localScale = newScale;
            
            if (t > 1)
            {
                enabled = false;
            }
        }
    }
    
    public void ResetDrilling()
    {
        enabled = true; 
        t = 0; 
        transform.localScale = startScale; 
        isDrilling = false; 
    }
}