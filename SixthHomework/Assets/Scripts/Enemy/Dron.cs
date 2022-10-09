using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] float _timeToReachSpeed;

    [SerializeField] ParticleSystem _fire;
    [SerializeField] List<ParticleSystem> _smoke;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = PlayerController.Instance.GetPlayerTransform();
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rb.mass * (toPlayer * _speed - _rb.velocity) / _timeToReachSpeed;

        _rb.AddForce(force);
    }
    public void StartSmoke()
    {
        for (int i = 0; i < _smoke.Count; i++)
        {
            _smoke[i].Play();
        }
    }

    public void StartFire()
    {
        _fire.Play();
    }
}
