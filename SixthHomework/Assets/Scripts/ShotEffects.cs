using UnityEngine;

public class ShotEffects : MonoBehaviour
{
    void Start()
    {
        ParticleSystem particle = GetComponent<ParticleSystem>();
        Destroy(gameObject, particle.duration);
    }
}
