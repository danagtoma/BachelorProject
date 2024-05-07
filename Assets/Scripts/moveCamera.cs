using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;  // The point around which the camera orbits
    public float distance = 10f;  // Distance from the target
    public float horizontalSpeed = 100f;  // Speed of horizontal movement
    public float verticalSpeed = 50f;  // Speed of vertical movement
    public float minVerticalAngle = -30f;  // Minimum vertical angle
    public float maxVerticalAngle = 60f;  // Maximum vertical angle

    private float horizontalAngle = 0f;  // Current horizontal angle around the target
    private float verticalAngle = 0f;  // Current vertical angle

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target is not assigned for OrbitCamera.");
            return;
        }

        // Initialize camera position based on the initial angles
        SetCameraPosition();
    }

    void Update()
    {
        // Get horizontal movement input (left/right)
        float horizontalInput = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        horizontalAngle += horizontalInput * horizontalSpeed * Time.deltaTime;

        // Get vertical movement input (up/down)
        float verticalInput = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        verticalAngle += verticalInput * verticalSpeed * Time.deltaTime;

        // Clamp the vertical angle to avoid flipping the camera
        verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);

        // Update the camera position
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        // Calculate the new position for the camera
        Quaternion rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
        Vector3 offset = new Vector3(0, 0, -distance);
        transform.position = target.position + rotation * offset;

        // Make the camera always look at the target
        transform.LookAt(target);
    }
}
