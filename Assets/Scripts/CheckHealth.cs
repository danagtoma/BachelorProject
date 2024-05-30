using UnityEngine;

public class ChechHealth : MonoBehaviour
{
    [SerializeField] private string bacteria = "bacteria";
    [SerializeField] private HealthManager healthManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bacteria))
        {
            Destroy(other.gameObject);
            healthManager.TakeDamage(20);
        }
    }
}
