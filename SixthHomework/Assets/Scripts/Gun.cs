using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] Transform _spawn;
    [SerializeField] float _bulletSpeed = 20;
    [SerializeField] float _shotPeriod = 0.4f;
    [SerializeField] ParticleSystem _shotEffect;

    [SerializeField] AudioSource _shotSound;

    private float _timer;
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _shotPeriod)
            if (Input.GetMouseButton(0))
            {
                _timer = 0;

                Bullet newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;

                _shotEffect.Play();
                _shotSound.Play();
            }
    }
}
