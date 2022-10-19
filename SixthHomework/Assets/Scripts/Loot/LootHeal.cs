using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] int _healthValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>() is PlayerHealth playerHealth)
            if(playerHealth.Health < playerHealth.MaxHealth)
            {
                playerHealth.AddHealth(_healthValue);
                Destroy(gameObject);
            }
    }
}
