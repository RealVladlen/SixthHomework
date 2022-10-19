using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    #region Синглтон
    public static EnemyHealthController Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
            Destroy(gameObject);

        else
            Instance = this;
    }
    #endregion

    [SerializeField] AudioSource _explosionSound;

    public AudioSource GetExplosionAudioTransform()
    {
        return _explosionSound;
    }
}
