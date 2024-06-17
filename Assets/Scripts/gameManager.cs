using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ToothSpawner toothSpawner;
    public int scene;
    public List<GameObject> pressedTeeth = new List<GameObject>();
    private int totalTeeth;
    private bool gameFinished = false;
    public float seconds = 3f;

    void Start()
    {
        totalTeeth = FindObjectsOfType<Tooth>().Length;
    }

    public void AddPressedTooth(GameObject tooth)
    {
        if (!pressedTeeth.Contains(tooth))
        {
            pressedTeeth.Add(tooth);
        }

        if (pressedTeeth.Count == totalTeeth)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        if (!gameFinished)
        {
            StartCoroutine(EndGameCoroutine());
            gameFinished = true;
        }
    }

    private IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(scene);
    }
}
