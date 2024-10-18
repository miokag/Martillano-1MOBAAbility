using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject bindSpherePrefab;
    private GameObject bindSphere;

    public float movementDistance = 3f;
    public float movementSpeed = 2f;
    public float lerpSpeed = 5f; 

    private Vector3 bindedPosition;
    private bool isBinded = false;
    private float timeOffset;

    private void Start()
    {
        bindedPosition = transform.position;
        timeOffset = Random.Range(0f, movementDistance);
    }

    private void Update()
    {
        if (!agent.isStopped)
        {
            if (isBinded)
            {
                isBinded = false; 
            }

            MoveSideToSide();
        }
        else
        {
            isBinded = true; 
            bindedPosition = transform.position;
        }
    }

    public void InitiateBindEffect()
    {
        bindSphere = Instantiate(bindSpherePrefab, transform.position, Quaternion.identity);
        bindSphere.transform.SetParent(transform);
        StartCoroutine(RemoveBind(2f)); 
        agent.isStopped = true;
    }


    private IEnumerator RemoveBind(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (bindSphere != null)
        {
            Destroy(bindSphere);
            bindSphere = null;
            Debug.Log("Bind Effect Removed");
        }

        agent.isStopped = false;
    }

    private void MoveSideToSide()
    {
        float movementOffset = Mathf.PingPong(Time.time * movementSpeed + timeOffset, movementDistance) - (movementDistance / 2);

        Vector3 targetPosition = bindedPosition + new Vector3(movementOffset, 0f, 0f);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
    }
}
