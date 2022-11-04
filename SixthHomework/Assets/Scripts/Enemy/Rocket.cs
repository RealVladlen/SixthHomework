using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Rigidbody _rb;
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] ParticleSystem _particleSystem;

    private void Start()
    {
        Transform _playerTransform = PlayerController.Instance.GetPlayerTransform();
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        gameObject.transform.rotation = Quaternion.LookRotation(toPlayer);
        _rb.velocity = toPlayer * _speed;
        _enemyHealth.EventOnDie.AddListener(Die);
    }
    public void Die()
    {
        _particleSystem.Stop();
        _particleSystem.transform.parent = null;
        Destroy(_particleSystem.gameObject, 4);
    }
}
