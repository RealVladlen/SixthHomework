using UnityEngine;

public class SmallRocket : MonoBehaviour
{
    [SerializeField] float _speed, _rotationSpeed;
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] ParticleSystem _particleSystem;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = PlayerController.Instance.GetPlayerTransform();
        _enemyHealth.EventOnDie.AddListener(Die);
    }

    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;

        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
    public void Die()
    {
        _particleSystem.Stop();
        _particleSystem.transform.parent = null;
        Destroy(_particleSystem.gameObject, 4);
    }
}
