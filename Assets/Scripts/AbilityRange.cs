using UnityEngine;

public class AbilityRange : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ability"))
        {
            Debug.Log("Ability projectile entered the range.");
            Destroy(other.gameObject);
        }
    }
}
