using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] Renderer[] _renderer;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            for (int i = 0; i < _renderer.Length; i++)
                _renderer[i].material.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));

            yield return null;
        }
    }
}
