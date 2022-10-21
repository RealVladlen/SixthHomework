using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}
public class Walker : MonoBehaviour
{
    [SerializeField] Transform _leftTarget, _rightTarget;
    [SerializeField] float _speed, _rotationSpeed;
    [SerializeField] float _stopTime;
    [SerializeField] Transform _rayStart;

    public Direction CurrentDirection;

    private bool _isStopped;

    public UnityEvent EventOnRight;
    public UnityEvent EventOnLeft;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }

    private void Update()
    {
        if (_isStopped) return;

        if(CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if (transform.position.x < _leftTarget.position.x)
            {
                CurrentDirection = Direction.Right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                EventOnLeft.Invoke();
            }
        }

        else
        {
            transform.position += new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if (transform.position.x > _rightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                EventOnRight.Invoke();
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(_rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    void ContinueWalk()
    {
        _isStopped = false;
    }
}
