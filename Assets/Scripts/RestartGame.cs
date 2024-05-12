using UnityEngine;
using UnityEngine.UI; 

public class RestartGame : MonoBehaviour
{
    public Transform cavityBlack;
    public Transform cavityRed;
    public Vector3 cavityBlackDefaultScale = new Vector3(1, 1, 1);
    public Vector3 cavityRedDefaultScale = new Vector3(0.55f, 0.55f, 0.55f);
    public DrillOperating drillScript;
    public FillCavity fillCavity;
    public GameObject smallMaterial;
    public GameObject drill;
    public GameObject spatula;

    Vector3 startDrillPosition;
    Vector3 startSpatulaPosition;
    Quaternion startDrillRotation;
    Quaternion startSpatulaRotation;
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ResetTargetScale); 
        }
        if(drill != null)
        {
            startDrillPosition = drill.transform.position;
            startDrillRotation = drill.transform.rotation;
        }
        if (spatula != null)
        {
            startSpatulaPosition = spatula.transform.position;
            startSpatulaRotation = spatula.transform.rotation;
        }
    }

    public void ResetTargetScale()
    {
        if (cavityBlack != null)
        {
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
        if (drill != null)
        {
            drill.transform.SetPositionAndRotation(startDrillPosition, startDrillRotation );
        }
        if (spatula != null)
        {
            spatula.transform.SetPositionAndRotation(startSpatulaPosition, startSpatulaRotation);
        }
    }
}
