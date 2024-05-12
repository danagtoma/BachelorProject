using UnityEngine;

public class ToothRotation : MonoBehaviour
{
    public float rotationSpeed = 0.5f;  
    private Vector3 previousMousePosition;
    private bool isDragging = false;
    public LayerMask layer;
    private Transform linkedObject;

    void Start()
    {
        GameObject linkedObjectGameObject = GameObject.FindGameObjectWithTag("cavity");
        if (linkedObjectGameObject != null)
        {
            linkedObject = linkedObjectGameObject.transform;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverObject())
            {
                isDragging = true;
                previousMousePosition = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 delta = currentMousePosition - previousMousePosition;

            float deltaX = delta.x * rotationSpeed;
            float deltaY = delta.y * rotationSpeed;

            transform.Rotate(Vector3.up, -deltaX, Space.World);   
            transform.Rotate(Vector3.right, deltaY, Space.World); 

            previousMousePosition = currentMousePosition;
        }
    }

    private bool IsMouseOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.transform == transform; 
        }

        return false;
    }
}