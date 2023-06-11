using UnityEngine;

public class ParticleSystemDestroying : MonoBehaviour
{
    public ParticleSystem particle;

    private void Update()
    {
        if (!particle.isPlaying && particle.particleCount == 0)
        {
            Destroy(gameObject);
        }
    }
}