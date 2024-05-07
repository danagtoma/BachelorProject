using UnityEngine;

public class DrillIntoSphere : MonoBehaviour
{

    public float ShrinkDuration = 5f;

    // The target scale
    public Vector3 TargetScale = Vector3.one * .0001f;

    // The starting scale
    Vector3 startScale;

    // T is our interpolant for our linear interpolation.
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
        // initialize stuff in OnEnable
        startScale = transform.localScale;
        t = 0;
        isDrilling = false;
    }

    void Update()
    {
        if (isDrilling)
        {
            // Divide deltaTime by the duration to stretch out the time it takes for t to go from 0 to 1.
            t += Time.deltaTime / ShrinkDuration;

            // Lerp wants the third parameter to go from 0 to 1 over time. 't' will do that for us.
            Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);
            transform.localScale = newScale;

            // We're done! We can disable this component to save resources.
            if (t > 1)
            {
                enabled = false;
            }
        }
    }

    // Method to restart the drilling
    public void ResetDrilling()
    {
        enabled = true; // Enable the script again
        t = 0; // Reset the interpolant
        transform.localScale = startScale; // Reset the scale to its original
        isDrilling = false; // Reset the drilling flag
    }
}
