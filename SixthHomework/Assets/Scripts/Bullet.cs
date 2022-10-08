using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _effect;
    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
