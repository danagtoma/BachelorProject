using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform target;  
    public float distance = 10f;  
    public float horizontalSpeed = 100f;  
    public float verticalSpeed = 50f;  
    public float minVerticalAngle = -30f;  
    public float maxVerticalAngle = 60f;  

    private float horizontalAngle = 0f;  
    private float verticalAngle = 0f;  

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target is not assigned for OrbitCamera.");
            return;
        }

        SetCameraPosition();
    }

    void Update()
    {
        float horizontalInput = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        horizontalAngle += horizontalInput * horizontalSpeed * Time.deltaTime;

        float verticalInput = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        verticalAngle += verticalInput * verticalSpeed * Time.deltaTime;

        verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);

        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
        Vector3 offset = new Vector3(0, 0, -distance);
        transform.position = target.position + rotation * offset;

        transform.LookAt(target);
    }
}
