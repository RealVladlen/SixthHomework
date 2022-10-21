using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] Vector3 _leftEuler, _rightEuler;
    [SerializeField] float _rotateionSpeed;

    private Vector3 _targetEuler;

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotateionSpeed);
    }

    public void RotateLeft()
    {
        _targetEuler = _leftEuler;
    }

    public void RotateRight()
    {
        _targetEuler = _rightEuler;
    }
}
