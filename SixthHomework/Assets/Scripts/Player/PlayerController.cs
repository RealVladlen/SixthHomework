using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region ��������
    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] Transform _playerTransform;

    public Transform GetPlayerTransform()
    {
        return _playerTransform;
    }
}
