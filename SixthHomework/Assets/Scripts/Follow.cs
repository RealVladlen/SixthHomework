using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _lerpRate;
    [SerializeField] Vector3 _offset;  

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpRate);    
    }
}
