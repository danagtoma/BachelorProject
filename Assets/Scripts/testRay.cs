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

                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 2.0f);
            }
        }
    }
}
