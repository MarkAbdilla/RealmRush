using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    [SerializeField] float dwellTime = 2f;

    void Start()
    {
        StartCoroutine(PrintAllWaypoints());
    }

    IEnumerator PrintAllWaypoints()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
    }

    void Update()
    {
        
    }
}
