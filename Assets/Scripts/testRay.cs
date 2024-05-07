using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit: " + hit.transform.name);

                // Draw the ray in the Scene view (visible while the scene is playing)
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 2.0f);
            }
        }
    }
}
