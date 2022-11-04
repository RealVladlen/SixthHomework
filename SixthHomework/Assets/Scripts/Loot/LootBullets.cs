using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] int _gunIndex;
    [SerializeField] int _numberOfBullets;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerArmory>() is PlayerArmory playerHealth)
        {
            playerHealth.AddBullets(_gunIndex, _numberOfBullets);
            Destroy(gameObject);
        }
    }
}
