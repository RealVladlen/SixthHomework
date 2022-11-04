using UnityEngine;
using TMPro;

public class Automat : Gun
{
    [Header("Automat")]
    [SerializeField] int _numberOfBullets;
    [SerializeField] TextMeshProUGUI _bulletText;
    [SerializeField] PlayerArmory _playerArmory;

    public override void Shot()
    {
        base.Shot();

        _numberOfBullets--;
        UpdateText();

        if (_numberOfBullets == 0)
        {
            _playerArmory.TakeGunIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        _bulletText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _bulletText.enabled = false;
    }

    private void UpdateText()
    {
        _bulletText.text = _numberOfBullets.ToString("00");
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        _numberOfBullets += numberOfBullets;
        UpdateText();
        _playerArmory.TakeGunIndex(1);
    }
}
