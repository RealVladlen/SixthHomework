using UnityEngine.Events;
using UnityEngine;

public class DronHealth : MonoBehaviour
{
    [SerializeField] int _health = 5;
    [SerializeField] ParticleSystem _takeDamage;
    [SerializeField] Dron _dron;
    [SerializeField] AudioSource _explosion;

    public UnityEvent EventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
            Die();
        if (_health == 2)
            _dron.StartSmoke();
        if (_health == 1)
            _dron.StartFire();

        EventOnTakeDamage.Invoke();
        Instantiate(_takeDamage, transform.position, Quaternion.identity).Play();
    }

    private void Die()
    {
        Destroy(gameObject);

        AudioSource explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(explosion.gameObject, 2);
    }
}
