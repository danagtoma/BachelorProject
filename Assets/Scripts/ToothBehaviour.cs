using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{
    private List<GameObject> activatedTeeth = new();
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager script not found in the scene.");
        }
    }

    void OnMouseDown()
    {
        gameObject.SetActive(false);

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(gameObject.tag);
        foreach (GameObject obj in objectsWithTag)
        {
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
                activatedTeeth.Add(obj);
                break;
            }
        }
        if (gameManager != null)
        {
            gameManager.AddPressedTooth(gameObject);
        }
        else
        {
            Debug.LogWarning("GameManager reference is null.");
        }
    }
    public void ResetTooth()
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }

        foreach (GameObject activatedTooth in activatedTeeth)
        {
            MeshRenderer activatedMeshRenderer = activatedTooth.GetComponent<MeshRenderer>();
            if (activatedMeshRenderer != null)
            {
                activatedMeshRenderer.enabled = false;
            }
        }

        activatedTeeth.Clear();
    }
}
