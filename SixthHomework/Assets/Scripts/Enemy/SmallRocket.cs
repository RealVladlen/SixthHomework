using UnityEngine;

public class SmallRocket : MonoBehaviour
{
    [SerializeField] float _speed, _rotationSpeed;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = PlayerController.Instance.GetPlayerTransform();
    }

    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;

        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
