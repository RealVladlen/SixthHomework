using System.Collections.Generic;
using UnityEngine;

public class EnemySetActive : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemyList;
    [SerializeField] float _distanceToActivate = 30;

    private Transform _player;

    #region Синглтон
    public static EnemySetActive Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        _player = PlayerController.Instance.GetPlayerTransform();
    }

    private void FixedUpdate()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {

            float distance = Vector3.Distance(_enemyList[i].transform.position, _player.position);
            if (distance < _distanceToActivate)
            {
                _enemyList[i].SetActive(true);
                _enemyList.RemoveAt(i);
            }
        }
    }

    public void SetEnemy(GameObject enemy)
    {
        _enemyList.Add(enemy);
        enemy.SetActive(false);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        _enemyList.Remove(enemy);
    }
}
