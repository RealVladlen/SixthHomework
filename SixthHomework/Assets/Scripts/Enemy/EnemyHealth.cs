using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
