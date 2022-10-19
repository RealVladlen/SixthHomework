using UnityEngine;

public class RotateToEnemmy : MonoBehaviour
{
    [SerializeField] Vector3 _leftEuler, _rightEuler;
    [SerializeField] float _rotatiionSpeed;

    private Vector3 _targetEuler;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = PlayerController.Instance.GetPlayerTransform();
    }

    void Update()
    {
        if (transform.position.x < _playerTransform.position.x)
            _targetEuler = _rightEuler;
        else
            _targetEuler = _leftEuler;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotatiionSpeed);
    }
}
