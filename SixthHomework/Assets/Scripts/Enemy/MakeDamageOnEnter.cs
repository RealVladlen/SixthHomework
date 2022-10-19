using UnityEngine;

public class MakeDamageOnEnter : MonoBehaviour
{
    [SerializeField] int _damageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Touch(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        Touch(other);
    }

    private void Touch(Collider collider)
    {
        if (collider.attachedRigidbody)
        {
            PlayerHealth playerHealth = collider.attachedRigidbody.GetComponent<Rigidbody>().GetComponent<PlayerHealth>();

            if (playerHealth)
                playerHealth.TakeDamage(_damageValue);
        }
    }
}
