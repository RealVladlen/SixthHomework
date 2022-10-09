using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] EnemyHealth _enemyHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
            if (collision.rigidbody.GetComponent<Bullet>())
                _enemyHealth.TakeDamage(1);
    }
}
