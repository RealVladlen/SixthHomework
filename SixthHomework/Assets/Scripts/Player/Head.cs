using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Head : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _aim;
    [SerializeField] Transform _head;
    [SerializeField] Transform _player;

    [SerializeField] float _angle;

    void Update()
    {
        transform.position = _target.position;

        float target = (_aim.position.x >= _player.position.x) ? -45f : 45f;
        _angle = Mathf.Lerp(_angle, target, Time.deltaTime * 10);
        _head.eulerAngles = new Vector3(0, _angle, 0);
    }
}
