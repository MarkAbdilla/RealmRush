using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        ColourStartAndEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            print("Exploring " + explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColour(Color.yellow);
            }
            catch
            {

            }
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block found " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColour(Color.black);
            }
        }
    }

    private void ColourStartAndEnd()
    {
        startWaypoint.SetTopColour(Color.blue);
        endWaypoint.SetTopColour(Color.red);
    }
}
