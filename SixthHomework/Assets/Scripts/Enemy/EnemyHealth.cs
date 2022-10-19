using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health = 1;
    [SerializeField] ParticleSystem _takeDamage;

    private AudioSource _explosion;

    public UnityEvent<int> EventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
            Die();
        else
            EventOnTakeDamage.Invoke(_health);

        CreateDamageEffect();
    }

    private void Die()
    {
        Destroy(gameObject);

        _explosion = EnemyHealthController.Instance.GetExplosionAudioTransform();
        AudioSource explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(explosion.gameObject, explosion.clip.length);
    }

    private void CreateDamageEffect()
    {
        if (!_takeDamage) return;

        ParticleSystem effect = Instantiate(_takeDamage, transform.position, Quaternion.identity);
        effect.transform.localScale = new Vector3(2, 2, 2);
        effect.Play();
    }
}
