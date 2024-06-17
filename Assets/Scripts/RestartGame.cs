using System.Collections.Generic;
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
    public GameObject brush;
    public BacteriaSpawner bacteriaSpawner;
    public StartAttack startAttack;
    public HealthManager healthManager;
    public DestroyBacteria destroyBacteria;
    public CountdownManager countdownManager;
    public ToothSpawner toothSpawner;
    public List<Tooth> teeth;

    Vector3 startDrillPosition;
    Vector3 startSpatulaPosition;
    Vector3 startBrushPositon;
    Quaternion startDrillRotation;
    Quaternion startSpatulaRotation;
    Quaternion startBrushRotation;
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
        if (brush != null)
        {
            startBrushPositon = brush.transform.position;
            startBrushRotation = brush.transform.rotation;
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
        if (brush != null)
        {
            brush.transform.SetPositionAndRotation(startBrushPositon, startBrushRotation);
            bacteriaSpawner.ResetBacteriaSpawner();
            startAttack.RestartAttack();
            healthManager.Heal(100);
            destroyBacteria.FillPaste(100);
            countdownManager.StopCountDown();
        }
        toothSpawner.ResetTeethSpawner();
        foreach (Tooth tooth in teeth)
        {
            tooth.ResetTooth();
        }
    }
}
