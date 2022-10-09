using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _maxHealth;
    [SerializeField] ParticleSystem _healthEffect;
    [SerializeField] AudioSource _takeDamageSound, _addHealthSound;
    [SerializeField] HealthUI _healthUI;
    [SerializeField] DamageScreen _damageScreen;
    [SerializeField] Blink _blink;

    public UnityEvent EventOnTakeDamage;

    private bool _invulnerable;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }

    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            _health -= damageValue;

            if (_health <= 0)
                Die();

            _invulnerable = true;
            Invoke("StopInvulnerable", 1);
            _healthUI.DisplayHealth(_health);
            EventOnTakeDamage.Invoke();
        }
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;

        if (_health > _maxHealth)
            _health = _maxHealth;

        _healthEffect.Play();
        _addHealthSound.Play();
        _healthUI.DisplayHealth(_health);
    }

    private void Die()
    {
        Debug.Log("You die");
    }
}
