using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Update()
    {
        if (_particleSystem.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
