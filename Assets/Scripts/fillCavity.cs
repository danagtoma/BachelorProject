using UnityEngine;

public class FillCavity : MonoBehaviour
{
    public float GrowDuration = 5f;  // The time it takes for the object to grow

    // The target scale when growing is completed
    public Vector3 TargetScale = Vector3.one * 1f;

    // The starting scale before growing begins
    private Vector3 startScale;

    // Interpolant for linear interpolation
    private float t = 0;

    // Flag indicating whether growing is happening
    private bool isGrowing = false;

    public GameObject cavityBlack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("material"))  // Start growing when the specified object enters
        {
            isGrowing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("material"))  // Stop growing when the specified object exits
        {
            isGrowing = false;
        }
    }

    void OnEnable()
    {
        // Initialize start scale and reset interpolant
        startScale = transform.localScale;
        t = 0;
        isGrowing = false;
    }

    void Update()
    {
        if (isGrowing && cavityBlack.transform.localScale.x < 0.55f)
        {
            // Update the interpolant over time
            t += Time.deltaTime / GrowDuration;

            // Interpolate from the starting scale to the target scale
            Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);

            // Apply the new scale
            transform.localScale = newScale;

            // If the interpolant has reached or surpassed 1, growing is complete
            if (t >= 1)
            {
                isGrowing = false; // Stop the growing
                enabled = false;  // Optionally, disable the script to save resources
            }
        }
    }

    // Method to reset and restart the growing process
    public void ResetGrowing()
    {
        enabled = true;  // Enable the script to start growing again
        t = 0;  // Reset the interpolant
        transform.localScale = startScale;  // Reset to initial scale
        isGrowing = false;  // Reset the growing flag
    }
}
