using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _effect;
    [SerializeField] public int _damage { get; private set; } = 1;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit();
    }

    public void Hit()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
