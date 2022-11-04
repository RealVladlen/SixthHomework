using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button _restartButton, _continueButton, _menuButton;
    [SerializeField] Toggle _musicToggle;
    [SerializeField] Slider _audioSlider;
    [SerializeField] CanvasGroup _menuButtonCanvas, _menuPanelCanvas;
    [SerializeField] MonoBehaviour[] _componentsToDisable;

    private Tween _tween;

    private void Awake()
    {
        _menuButton.onClick.AddListener(ShowMenu);
        _continueButton.onClick.AddListener(HideMenu);
        _restartButton.onClick.AddListener(RestartLevel);
        _musicToggle.onValueChanged.AddListener(SetMusicEnable);
        _audioSlider.onValueChanged.AddListener(SetVolume);

        _menuPanelCanvas.alpha = 0;
        _menuPanelCanvas.gameObject.SetActive(false);
    }

    private void SetMusicEnable(bool value)
    {
        SoundController.Instance.SetMusicEnable(value);
    }

    private void SetVolume(float value)
    {
        SoundController.Instance.SetVolume(value);
    }

    private void ShowMenu()
    {
        ComponentsToDisable(false);

        _tween = _menuButtonCanvas.DOFade(0, 0.25f).SetUpdate(UpdateType.Normal,true);
        _tween.onComplete += () =>
        {
            _menuButtonCanvas.gameObject.SetActive(false);
            _menuPanelCanvas.gameObject.SetActive(true);
            _menuPanelCanvas.DOFade(1, 0.5f).SetUpdate(UpdateType.Normal, true);
        };
        DOTween.To(value => Time.timeScale = value, 1, 0.001f, 0.4f).OnUpdate(() => { if (Time.timeScale < 0.001f) Time.timeScale = 0.001f; }).SetEase(Ease.InCubic);
    }

    private void HideMenu()
    {
        ComponentsToDisable(true);

        _tween = _menuPanelCanvas.DOFade(0, 0.25f).SetUpdate(UpdateType.Normal, true);
        _tween.onComplete += () =>
        {
            _menuPanelCanvas.gameObject.SetActive(false);
            _menuButtonCanvas.gameObject.SetActive(true);
            _menuButtonCanvas.DOFade(1, 0.5f).SetUpdate(UpdateType.Normal, true);
        };

        DOTween.To(value => Time.timeScale = value, 0.001f, 1, 0.4f).OnUpdate(() => { if (Time.timeScale > 1) Time.timeScale = 1; }).SetEase(Ease.InCubic);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ComponentsToDisable(bool boolState)
    {
        for (int i = 0; i < _componentsToDisable.Length; i++)
            _componentsToDisable[i].enabled = boolState;
    }
}
