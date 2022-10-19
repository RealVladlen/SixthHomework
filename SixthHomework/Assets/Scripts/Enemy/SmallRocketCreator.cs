using System.Collections;
using UnityEngine;

public class SmallRocketCreator : MonoBehaviour
{
    [SerializeField] SmallRocket _rocketPrefab;
    [SerializeField] Transform _spawnTransform;

    private void Start()
    {
        StartCoroutine(ShootTimer());
    }

    public void Create()
    {
        Instantiate(_rocketPrefab, _spawnTransform.position, _spawnTransform.rotation);
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(3);

        Create();

        StartCoroutine(ShootTimer());
    }
}
