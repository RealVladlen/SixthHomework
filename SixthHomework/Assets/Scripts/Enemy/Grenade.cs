using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Vector3 Velocity;
    [SerializeField] float _maxRotationSpeed;
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed));
    }
}
