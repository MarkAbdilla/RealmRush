using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColour, unexploredColour;

    public bool isExplored = false;
    public Waypoint exploredFrom;

    Vector2Int gridPos;

    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    void SetOwnColour()
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        if (isExplored)
        {
            topMeshRenderer.material.color = exploredColour;
        }
        else
        {
            topMeshRenderer.material.color = unexploredColour;
        }
    }

    private void Update()
    {
        SetOwnColour();
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
}
