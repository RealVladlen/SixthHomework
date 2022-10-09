using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] int _healthValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.AddHealth(_healthValue);
            Destroy(gameObject);
        }
    }
}
