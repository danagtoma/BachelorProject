using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private float zCoordinate;

    void OnMouseDown()
    {
        // Save the z-coordinate of the object relative to the camera
        zCoordinate = Camera.main.WorldToScreenPoint(transform.position).z;

        // Calculate offset between the object's world position and mouse position
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        // Set the position to the mouse world position + offset
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Create a point in world space where the mouse is, using its screen position and z-coordinate
        Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zCoordinate);
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
