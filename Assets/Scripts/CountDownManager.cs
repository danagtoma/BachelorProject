using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public int finalScene;
    private bool stopCountdown = false;
    private Coroutine countdownCoroutine;

    public void StartCountdown(int duration)
    {
        stopCountdown = false;
        countdownCoroutine = StartCoroutine(CountdownCoroutine(duration));
    }

    private IEnumerator CountdownCoroutine(int duration)
    {
        int remainingTime = duration;

        while (remainingTime > 0)
        {
            countdownText.text = "Timp Ramas: " + remainingTime.ToString() + "s";
            yield return new WaitForSeconds(1);
            remainingTime--;
        }

        if (!stopCountdown)
        {
            countdownText.text = "Timpul a expirat!";
            SceneManager.LoadScene(finalScene);
        }
    }

    public void StopCountDown()
    {
        stopCountdown = true;
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
        countdownText.text = "Tmpiul este oprit";
    }
}
