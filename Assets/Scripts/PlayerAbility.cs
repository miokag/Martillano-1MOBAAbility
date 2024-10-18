using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public Transform bindSpawnPoint;
    public GameObject bindPrefab;
    public float bindSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        GameObject bind = Instantiate(bindPrefab, bindSpawnPoint.position, Quaternion.identity);

        Rigidbody rb = bind.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Get the mouse position in world space
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, bindSpawnPoint.position); 
            float enter;

            if (plane.Raycast(ray, out enter))
            {
                Vector3 mouseWorldPosition = ray.GetPoint(enter);

                Vector3 direction = (mouseWorldPosition - bindSpawnPoint.position).normalized;

                rb.velocity = direction * bindSpeed;
            }
        }
    }
}
