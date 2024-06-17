using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/*public class ToothSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnArea
    {
        public Vector3 minBounds;
        public Vector3 maxBounds;
    }

    public List<GameObject> objectsToSpawn; 
    public SpawnArea spawnArea;
    public int totalObjectsToSpawn = 16; 
    public float spawnInterval = 15f; 

    void Start()
    {
        StartCoroutine(SpawnObjectsAtIntervals());
    }

    IEnumerator SpawnObjectsAtIntervals()
    {
        for (int i = 0; i < totalObjectsToSpawn; i++)
        {
            if (objectsToSpawn.Count == 0)
            {
                Debug.LogWarning("All objects have been spawned.");
                yield break;
            }

            SpawnRandomObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomObject()
    {
        if (objectsToSpawn.Count == 0)
        {
            Debug.LogWarning("No objects to spawn. Add objects to the objectsToSpawn list.");
            return;
        }

        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        GameObject objectToSpawn = objectsToSpawn[randomIndex];

        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.minBounds.x, spawnArea.maxBounds.x),
            Random.Range(spawnArea.minBounds.y, spawnArea.maxBounds.y),
            Random.Range(spawnArea.minBounds.z, spawnArea.maxBounds.z)
        );

        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

        objectsToSpawn.RemoveAt(randomIndex);
    }
}*/

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


