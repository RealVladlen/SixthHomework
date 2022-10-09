using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Rigidbody _bulletPrefab;
    [SerializeField] Transform _spawn;
    [SerializeField] float _bulletSpeed = 20;
    [SerializeField] float _shotPeriod = 0.4f;
    [SerializeField] ParticleSystem _shotEffect;

    [SerializeField] AudioSource _shotSound;

    private float _timer;
    private void Update()
    {
        if (_timer <= _shotPeriod)
            _timer += Time.deltaTime;

        else if (Input.GetMouseButton(0))
        {
            _timer = 0;

            Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation).velocity = _spawn.forward * _bulletSpeed;

            _shotEffect.Play();
            _shotSound.Play();
        }
    }
}
