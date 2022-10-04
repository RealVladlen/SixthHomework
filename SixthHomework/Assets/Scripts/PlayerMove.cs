using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpSpeed;
    [SerializeField] float _friction;
    [SerializeField] bool _grounded;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Input.GetAxis("Horizontal") * _moveSpeed, 0, 0, ForceMode.VelocityChange);

        _rb.AddForce(-_rb.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
    }
}
