using UnityEngine;

public class RevealObjectOnCollision : MonoBehaviour
{

    public GameObject smallMaterial;

    private bool isRevealed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spatula"))
        {
            isRevealed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("spatula"))
        {
            isRevealed = false;
        }
    }

    void Update()
    {
        if (isRevealed)
        {
            if (smallMaterial != null)
            {
                smallMaterial.SetActive(true); 
                isRevealed = true; 
            }
        }
    }

}
