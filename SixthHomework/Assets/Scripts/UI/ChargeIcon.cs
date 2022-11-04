using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] Image _bg, _fg;
    [SerializeField] TextMeshProUGUI _text;

    public void StartCharge()
    {
        _bg.DOFade(0.2f, 0.5f);
        _fg.DOFade(0.7f, 0.5f);
        _text.DOFade(1, 0.5f);
    }

    public void StopCharge()
    {
        _bg.DOFade(1f, 0.5f);
        _fg.DOFade(0, 0.5f);
        _text.DOFade(0, 0.5f);
    }

    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        _fg.fillAmount = currentCharge / maxCharge;
        _text.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
}
