using DG.Tweening;
using UnityEngine;

public class ShowWeapons : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] _wapons;
    [SerializeField] CanvasGroup _canvasGroup;

    private bool _stateShow;

    private void Awake()
    {
        HideWeapon();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            if (!_stateShow)
                ShowWeapon();
    }

    private void ShowWeapon()
    {
        _stateShow = true;

        if (_canvasGroup != null && _stateShow == true)
            _canvasGroup.DOFade(1, 0.5f);

        for (int i = 0; i < _wapons.Length; i++)
            _wapons[i].enabled = true;
    }

    private void HideWeapon()
    {
        if (_canvasGroup != null)
            _canvasGroup.alpha = 0;

        for (int i = 0; i < _wapons.Length; i++)
            _wapons[i].enabled = false;
    }
}
