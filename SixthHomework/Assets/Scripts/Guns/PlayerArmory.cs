using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] Gun[] _guns;
    [SerializeField] int _currentGunIndex;

    void Start()
    {
        TakeGunIndex(_currentGunIndex);
    }

    public void TakeGunIndex(int gunIndex)
    {
        _currentGunIndex = gunIndex;

        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == _currentGunIndex)
                _guns[i].Activate();
            else
                _guns[i].Deactivate();
        }
    }   
    
    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        _guns[gunIndex].AddBullets(numberOfBullets);
    }
}
