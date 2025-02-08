using UnityEngine;

public class RandomParticleMovement : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        int numParticlesAlive = ps.GetParticles(particles = new ParticleSystem.Particle[ps.main.maxParticles]);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-0.1f, 0.1f),
                Random.Range(-0.1f, 0.1f),
                0
            );

            particles[i].position += randomOffset;
        }

        ps.SetParticles(particles, numParticlesAlive);
    }
}

// hello

