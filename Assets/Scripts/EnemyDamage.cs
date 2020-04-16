using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float hitPoints = 10f;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        ProcessDeath();
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1; //to consider different damage values according to tower
        hitParticlePrefab.Play();
    }

    private void ProcessDeath()
    {
        if (hitPoints <= 0)
        {
            var deathParticleFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            deathParticleFX.Play();
            Destroy(gameObject);
            Destroy(deathParticleFX, 1f);
        }
    }
}
