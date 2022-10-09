using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Rigidbody _rb;

    private void Start()
    {
        Transform _playerTransform = PlayerController.Instance.GetPlayerTransform();
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        _rb.velocity = toPlayer * _speed;
    }
}
