using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private int boundEnemyCount = 0;
    public int maxBoundEnemies = 2;
    public float bindDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (boundEnemyCount >= maxBoundEnemies)
            {
                Destroy(gameObject);
                return;
            }

            BindEnemy(other.GetComponent<EnemyMovement>());
        }
    }

    private void BindEnemy(EnemyMovement enemyMovement)
    {
        if (enemyMovement != null)
        {
            Debug.Log("Enemy Binded");

            boundEnemyCount++;
            Debug.Log("Count: " + boundEnemyCount);

            enemyMovement.agent.isStopped = true;
            enemyMovement.InitiateBindEffect();

            if (boundEnemyCount >= maxBoundEnemies)
            {
                Destroy(gameObject);
                return;
            }
        }
    }

   
}
