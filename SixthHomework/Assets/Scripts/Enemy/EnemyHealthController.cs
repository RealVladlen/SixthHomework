using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    #region ��������
    public static EnemyHealthController Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] AudioSource _explosionSound;

    public AudioSource GetExplosionAudioTransform()
    {
        return _explosionSound;
    }
}
