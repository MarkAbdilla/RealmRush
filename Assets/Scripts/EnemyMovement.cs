using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float dwellTime = 2f;
    [SerializeField] ParticleSystem goalParticlePrefab;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var deathParticleFX = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        deathParticleFX.Play();
        Destroy(deathParticleFX.gameObject, 1f);
        Destroy(gameObject);
    }
}
