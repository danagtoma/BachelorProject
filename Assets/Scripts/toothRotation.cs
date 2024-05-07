using UnityEngine;

public class DragRotateOnPress : MonoBehaviour
{
    public float rotationSpeed = 0.5f;  // Speed at which the object rotates
    private Vector3 previousMousePosition;
    private bool isDragging = false;
    public LayerMask layer;
    private Transform linkedObject;

    void Start()
    {
        // Find the linked object by its tag
        GameObject linkedObjectGameObject = GameObject.FindGameObjectWithTag("cavity");
        if (linkedObjectGameObject != null)
        {
            linkedObject = linkedObjectGameObject.transform;
        }
    }

    void Update()
    {
        // Start the drag when left mouse button is pressed over this object
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverObject())
            {
                isDragging = true;
                previousMousePosition = Input.mousePosition;
            }
        }

        // Stop the drag when the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Rotate the object while dragging
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 delta = currentMousePosition - previousMousePosition;

            float deltaX = delta.x * rotationSpeed;
            float deltaY = delta.y * rotationSpeed;

            transform.Rotate(Vector3.up, -deltaX, Space.World);   // Horizontal drag rotates around Y-axis
            transform.Rotate(Vector3.right, deltaY, Space.World); // Vertical drag rotates around X-axis

            //if (linkedObject != null)
            //{
              //  linkedObject.Rotate(Vector3.up, -deltaX, Space.World);   // Horizontal drag rotates around Y-axis
             //   linkedObject.Rotate(Vector3.right, deltaY, Space.World); // Vertical drag rotates around X-axis
           // }

            previousMousePosition = currentMousePosition;
        }
    }

    private bool IsMouseOverObject()
    {
        // Cast a ray from the camera to the mouse position and check if it hits this object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.transform == transform; // Return true if the ray hits this object
        }

        return false;
    }
}