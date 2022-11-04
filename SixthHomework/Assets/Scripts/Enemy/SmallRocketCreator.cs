using System.Collections;
using UnityEngine;

public class SmallRocketCreator : MonoBehaviour
{
    [SerializeField] SmallRocket _rocketPrefab;
    [SerializeField] Transform _spawnTransform;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(ShootTimer());
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(ShootTimer());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Create()
    {
        Instantiate(_rocketPrefab, _spawnTransform.position, _spawnTransform.rotation);
    }

    IEnumerator ShootTimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(3);

            Create();
        }
    }
}
