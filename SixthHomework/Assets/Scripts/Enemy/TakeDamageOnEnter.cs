using UnityEngine;

public class TakeDamageOnEnter : MonoBehaviour
{
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] bool _dieOnAnyCollisions;

    private void OnCollisionEnter(Collision collision)
    {
        Touch(collision.collider);

        if (_dieOnAnyCollisions)
            _enemyHealth.TakeDamage(999);
    }
    private void OnTriggerEnter(Collider other)
    {
        Touch(other);
    }
    private void Touch(Collider collider)
    {
        if (collider.attachedRigidbody && collider.attachedRigidbody.GetComponent<Bullet>() is Bullet bullet)
        {
            _enemyHealth.TakeDamage(bullet._damage);
            bullet.Hit();
        }
    }
}
