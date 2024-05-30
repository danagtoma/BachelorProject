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

    public void StartAttackFunction()
    {
           StartCoroutine(BacteriaSpawn());
    }

    IEnumerator BacteriaSpawn()
    {
        float currentSpawnSpeed = spawnSpeedMin;
        float currentMoveSpeed = moveSpeed;

        while (true)
        {
            

            var position = new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z);
            Quaternion randomRotation = Quaternion.Euler(Random.Range(0f, 360f), 0, 0);
            GameObject gameObject = Instantiate(bacteriaPrefab[Random.Range(0, bacteriaPrefab.Length)], position, randomRotation);

            StartCoroutine(MoveDown(gameObject, currentMoveSpeed));

            yield return new WaitForSeconds(Random.Range(spawnSpeedMin,spawnSpeedMax));

            Destroy(gameObject, 7f);

            currentSpawnSpeed -= spawnSpeedIncreaseRate;
            currentMoveSpeed += moveSpeedIncreaseRate;

            currentSpawnSpeed = Mathf.Clamp(currentSpawnSpeed, spawnSpeedMax, spawnSpeedMin);

        }
    }

    private IEnumerator MoveDown(GameObject bacteria, float speed)
    {
        while (bacteria != null)
        {
            bacteria.transform.Translate(mainCamera.transform.TransformDirection(Vector3.down) * speed * Time.deltaTime, Space.World);
            yield return null;
        }
    }
}