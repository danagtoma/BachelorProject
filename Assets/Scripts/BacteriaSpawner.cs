using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BacteriaSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] bacteriaPrefab;
    [SerializeField] float spawnSpeedMin = 1f;
    [SerializeField] float spawnSpeedMax = 2f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Camera mainCamera;
    [SerializeField] HealthManager healthManager;
    [SerializeField] float spawnSpeedIncreaseRate = 0.1f;
    [SerializeField] float moveSpeedIncreaseRate = 0.05f;
    private Coroutine spawnCoroutine;
    private readonly List<GameObject> spawnedObjects = new();

    public void StartAttackFunction()
    {
        //if (spawnCoroutine == null)
        //{
        //    spawnCoroutine = StartCoroutine(BacteriaSpawn());
        //}
        spawnCoroutine ??= StartCoroutine(BacteriaSpawn());
    }

    private IEnumerator BacteriaSpawn()
    {
        float currentSpawnSpeedMin = spawnSpeedMin;
        float currentSpawnSpeedMax = spawnSpeedMax;
        float currentMoveSpeed = moveSpeed;

        while (true)
        {
            var position = new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);

            GameObject prefab = bacteriaPrefab[Random.Range(0, bacteriaPrefab.Length)];
            Quaternion rotation;

            if (prefab.CompareTag("floss") || prefab.CompareTag("toothpaste"))
            {
                rotation = prefab.transform.rotation;
            }
            else
            {
                rotation = Quaternion.Euler(Random.Range(0f, 360f), 0, 0);
            }
            GameObject gameObject = Instantiate(prefab, position, rotation);
            spawnedObjects.Add(gameObject);

            StartCoroutine(MoveDown(gameObject, currentMoveSpeed));

            yield return new WaitForSeconds(Random.Range(currentSpawnSpeedMin, currentSpawnSpeedMax));

            Destroy(gameObject, 7f);
            StartCoroutine(RemoveObjectAfterDelay(gameObject, 7f));

            currentSpawnSpeedMin -= spawnSpeedIncreaseRate;
            //if(currentSpawnSpeedMax - spawnSpeedIncreaseRate >= 2)
            //{
                currentSpawnSpeedMax -= spawnSpeedIncreaseRate;
            //}
            currentMoveSpeed += moveSpeedIncreaseRate;

            currentSpawnSpeedMin = Mathf.Clamp(currentSpawnSpeedMin,0, spawnSpeedMax);
            currentSpawnSpeedMax = Mathf.Clamp(currentSpawnSpeedMax,2, spawnSpeedMax);
        }
    }

    private IEnumerator MoveDown(GameObject bacteria, float speed)
    {
        while (bacteria != null)
        {
            bacteria.transform.Translate(speed * Time.deltaTime * mainCamera.transform.TransformDirection(Vector3.down), Space.World);
            yield return null;
        }
    }

    private IEnumerator RemoveObjectAfterDelay(GameObject gameObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        spawnedObjects.Remove(gameObject);
    }

    public void ResetBacteriaSpawner()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }

        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        spawnedObjects.Clear();
    }

    public void DeleteObject(GameObject gameObject)
    {
        spawnedObjects.Remove(gameObject);
    }
}