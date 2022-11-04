using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    private Image _image;
    private Tween _tween;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.enabled = false;
    }

    public void ShowDamageEffects()
    {
        _image.enabled = true;

        _tween = _image.DOFade(1, 0.25f);
        _tween.onComplete += () =>
        {
            _tween = _image.DOFade(0, 1f);
            _tween.onComplete += () => 
            {
                _image.enabled = false;
            };
        };
    }
}
