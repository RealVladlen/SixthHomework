using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] bool _dieOnAnyCollisions;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
            if (collision.rigidbody.GetComponent<Bullet>())
                _enemyHealth.TakeDamage(1);

        if (_dieOnAnyCollisions)
            _enemyHealth.TakeDamage(999);
    }
}
