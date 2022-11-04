using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpSpeed;
    [SerializeField] float _friction;
    [SerializeField] float _maxSpeed;

    [SerializeField] bool _grounded;

    [SerializeField] Transform _colliderTransform;

    [SerializeField] Rigidbody _rb;


    private void Update()
    {
        float scale;

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !_grounded)
            scale = 0.65f;
        else
            scale = 1;

        _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1, scale, 1), Time.deltaTime * 15f);

        if (Input.GetKeyDown(KeyCode.Space))
            if (_grounded)
                _rb.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (!_grounded)
        {
            speedMultiplier = 0.1f;
            if (_rb.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
                speedMultiplier = 0;

            if (_rb.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
                speedMultiplier = 0;
        }

        _rb.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (_grounded)
            _rb.AddForce(-_rb.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);

            if (angle < 45f)
                _grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}
