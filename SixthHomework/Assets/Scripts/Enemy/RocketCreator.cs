using UnityEngine;

public class RocketCreator : MonoBehaviour
{
    [SerializeField] Rocket _rocketPrefab;
    [SerializeField] Transform _spawnTransform;

    public void Create()
    {
        Rocket newRocket = Instantiate(_rocketPrefab, _spawnTransform.position, Quaternion.identity);
        Destroy(newRocket, 5);
    }
}
