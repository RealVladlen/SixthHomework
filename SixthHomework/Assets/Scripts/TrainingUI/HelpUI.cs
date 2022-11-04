using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class HelpUI : MonoBehaviour
{
    private CanvasGroup _UICanvas;
    private bool _stateShow;
    private Tween _tween;

    private void Awake()
    {
        _UICanvas = GetComponent<CanvasGroup>();
        _UICanvas.alpha = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            if (!_stateShow)
                ShowUI();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            HideUI();
    }

    private void ShowUI()
    {
        _stateShow = true;
        _tween = _UICanvas.DOFade(1, 1);
    }

    private void HideUI()
    {
        _stateShow = false;
        _tween = _UICanvas.DOFade(0, 1);
    }
}
