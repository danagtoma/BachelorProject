using UnityEngine;
using UnityEngine.UI; // Required to use Unity UI components

public class ResetScale : MonoBehaviour
{
    public Transform cavityBlack;
    public Transform cavityRed;// Reference to the object to reset
    public Vector3 cavityBlackDefaultScale = new Vector3(1, 1, 1);
    public Vector3 cavityRedDefaultScale = new Vector3(0.55f, 0.55f, 0.55f);// The scale to reset to
    public DrillIntoSphere drillScript;
    public FillCavity fillCavity;
    public GameObject smallMaterial;
    void Start()
    {
        // Get the Button component and add a listener for the OnClick event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ResetTargetScale); // Add event listener for the button click
        }
    }

    void ResetTargetScale()
    {
        if (cavityBlack != null)
        {
            // Reset the target object's scale to the default value
            cavityBlack.localScale = cavityBlackDefaultScale;
            drillScript.ResetDrilling();
        }
        if(cavityRed != null)
        {
            cavityRed.localScale = cavityRedDefaultScale;
            fillCavity.ResetGrowing();
        }
        if(smallMaterial != null)
        {
            smallMaterial.SetActive(false);
        }
    }
}
