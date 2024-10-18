using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public float moveSpeed = 10f; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on the player.");
            return;
        }

        agent.speed = moveSpeed; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = ~LayerMask.GetMask("AbilityRange"); //To exclude

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    agent.SetDestination(hit.point);
                    agent.stoppingDistance = 0;
                }
            }
            else
            {
                Debug.Log("Raycast did not hit any object.");
            }
        }
    }
}
