using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ToothSpawner : MonoBehaviour
{
    public List<GameObject> teeth;
    public float activationInterval = 15f; 
    private List<GameObject> activatedTeeth;

    void Start()
    {
        activatedTeeth = new List<GameObject>();
        StartCoroutine(ActivateTeethRandomly());
    }

    private IEnumerator ActivateTeethRandomly()
    {
        while (teeth.Count > 0)
        {
            yield return new WaitForSeconds(activationInterval);

            ActivateRandomTooth();
        }
    }

    private void ActivateRandomTooth()
    {
        if (teeth.Count == 0) return;

        int randomIndex = UnityEngine.Random.Range(0, teeth.Count);
        GameObject tooth = teeth[randomIndex];

        MeshRenderer meshRenderer = tooth.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            Debug.LogWarning("MeshRenderer not found on tooth: " + tooth.name);
        }

        teeth.RemoveAt(randomIndex);
        activatedTeeth.Add(tooth);
    }

    public void ResetTeethSpawner()
    {
        foreach (GameObject tooth in activatedTeeth)
        {
            MeshRenderer meshRenderer = tooth.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
        }

        teeth.AddRange(activatedTeeth);
        activatedTeeth.Clear();
    }
}


