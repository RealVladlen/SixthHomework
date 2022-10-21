using System.Collections.Generic;
using UnityEngine;

public class EnemySetActive : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemyList;
    [SerializeField] float _distance = 30;

    private void FixedUpdate()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {

            float distance = Vector3.Distance(_enemyList[i].transform.position, gameObject.transform.position);
            if (distance < _distance)
            {
                _enemyList[i].SetActive(true);
                _enemyList.RemoveAt(i);
            }
        }
    }
}
