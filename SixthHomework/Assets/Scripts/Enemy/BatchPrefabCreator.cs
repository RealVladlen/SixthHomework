using System.Collections;
using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] Transform[] _spawnPoint;

    [SerializeField] Vector3 _velocity = new Vector3(0,0,5);

    private void Start()
    {
        StartCoroutine(WaitAndCreate());
    }

    IEnumerator WaitAndCreate()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_prefab, _spawnPoint[i].position, _spawnPoint[i].rotation);
            _prefab.GetComponent<Grenade>().Velocity = _velocity + new Vector3(0,0,Random.Range(0, 10));
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(WaitAndCreate());
    }
}
