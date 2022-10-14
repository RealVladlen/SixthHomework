using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health = 1;
    [SerializeField] ParticleSystem _takeDamage;

    private AudioSource _explosion;

    public UnityEvent EventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
            Die();
        EventOnTakeDamage.Invoke();
        ParticleSystem effect = Instantiate(_takeDamage, transform.position, Quaternion.identity);
        effect.gameObject.transform.localScale = new Vector3(2, 2, 2);
        effect.Play();
    }

    private void Die()
    {
        Destroy(gameObject);

        _explosion = EnemyHealthController.Instance.GetExplosionAudioTransform();
        AudioSource explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(explosion.gameObject, 2);
    }
}
