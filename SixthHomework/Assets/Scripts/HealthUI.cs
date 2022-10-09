using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameObject _healthIcon;

    [SerializeField] List<GameObject> _healthIcons = new List<GameObject>();
    public void Setup(int macHealth)
    {
        for (int i = 0; i < macHealth; i++)
        {
            GameObject newicon =  Instantiate(_healthIcon, transform);
            _healthIcons.Add(newicon);
        }
    }
    public void DisplayHealth(int health)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
            if (i < health)
                _healthIcons[i].SetActive(true);
            else
                _healthIcons[i].SetActive(false);
    }
}
