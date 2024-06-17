using UnityEngine;

public class TakeMaterial : MonoBehaviour
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
            Renderer renderer = GetComponent<Renderer>();
            if (smallMaterial != null)
            {
                Material material = renderer.material;
                Renderer smallMaterialRenderer = smallMaterial.GetComponent<Renderer>();
                smallMaterialRenderer.material = material;

                smallMaterial.SetActive(true); 
                isRevealed = true; 
            }
        }
    }

}
