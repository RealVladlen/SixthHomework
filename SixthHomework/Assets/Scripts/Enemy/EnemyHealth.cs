using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health = 1;
    [SerializeField] ParticleSystem _takeDamage;

    public UnityEvent EventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
            Die();
        EventOnTakeDamage.Invoke();
        Instantiate(_takeDamage, transform.position, Quaternion.identity).Play();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
