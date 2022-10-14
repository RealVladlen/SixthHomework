using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] int _damageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();

            if (playerHealth)
                playerHealth.TakeDamage(_damageValue);
        }
    }
}
