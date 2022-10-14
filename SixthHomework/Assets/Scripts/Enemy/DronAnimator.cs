using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronAnimator : MonoBehaviour
{
    [SerializeField] float _attackPeriod = 8;
    [SerializeField] Animator _animator;

    private float _timer;

    private void Update()
    {
        if (_timer <= _attackPeriod)
            _timer += Time.deltaTime;

        if (_timer >= _attackPeriod)
        {
            _timer = 0;
            _animator.SetTrigger("Attack");
        }
    }
}
