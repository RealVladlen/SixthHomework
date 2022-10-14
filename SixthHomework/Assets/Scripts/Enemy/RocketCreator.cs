using UnityEngine;

public class RocketCreator : MonoBehaviour
{
    [SerializeField] Rocket _rocketPrefab;
    [SerializeField] Transform _spawnTransform;

    public void Create()
    {
        Instantiate(_rocketPrefab, _spawnTransform.position, Quaternion.identity);
    }
}
