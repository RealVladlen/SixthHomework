using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] int _damageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            PlayerHealth playerHealth = collision.rigidbody.GetComponent<PlayerHealth>();

            if (playerHealth)
                playerHealth.TakeDamage(_damageValue);
        }
    }
}
