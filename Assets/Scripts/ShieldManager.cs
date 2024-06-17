using System.Collections;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject shieldObject;
    [SerializeField] private string enemyTag = "bacteria";
    [SerializeField] private BacteriaSpawner spawner;

    public void ShowShield()
    {
        if (shieldObject != null)
        {
            shieldObject.SetActive(true);
            StartCoroutine(HideShieldAfterDelay(5f));
        }
        else
        {
            Debug.LogWarning("Shield object is not assigned!");
        }
    }
    private IEnumerator HideShieldAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        HideShield(); 
    }

    public void HideShield()
    {
        if (shieldObject != null)
        {
            shieldObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Shield object is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Destroy(other.gameObject);
            spawner.DeleteObject(other.gameObject);
        }
    }
}
