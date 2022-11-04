using UnityEngine;
using DG.Tweening;

public class FinishFrame : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] MenuController _menuController;

    private bool _stateShow;

    private void Awake()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            if (!_stateShow)
                ShowUI();
    }

    private void ShowUI()
    {
        _canvasGroup.gameObject.SetActive(true);
        _canvasGroup.DOFade(1, 1).SetUpdate(UpdateType.Normal, true);
        DOTween.To(value => Time.timeScale = value, 1, 0.001f, 0.4f).OnUpdate(() => { if (Time.timeScale < 0.001f) Time.timeScale = 0.001f; }).SetEase(Ease.InCubic);
        _menuController.ComponentsToDisable(false);
    }
}
