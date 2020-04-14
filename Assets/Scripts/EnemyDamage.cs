using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float hitPoints = 10f;

    private void OnParticleCollision(GameObject other)
    {
        hitPoints = hitPoints - 1; //to consider different damage values according to tower

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
