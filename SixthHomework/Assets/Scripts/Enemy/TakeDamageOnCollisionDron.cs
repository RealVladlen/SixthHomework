using UnityEngine;

public class TakeDamageOnCollisionDron : MonoBehaviour
{
    [SerializeField] DronHealth _dronHealth;
    [SerializeField] bool _dieOnAnyCollisions;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
            if (collision.rigidbody.GetComponent<Bullet>())
                _dronHealth.TakeDamage(1);

        if (_dieOnAnyCollisions)
            _dronHealth.TakeDamage(999);
    }
}
