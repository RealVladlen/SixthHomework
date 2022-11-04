using UnityEngine;

public class SoundController : MonoBehaviour
{
    #region ��������
    public static SoundController Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] AudioSource _music;
    public void SetMusicEnable(bool value)
    {
        _music.enabled = value;
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
