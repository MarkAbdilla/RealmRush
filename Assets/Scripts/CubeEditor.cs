using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    TextMesh textMesh;
    Vector3 gridPos;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * 10f;
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * 10f;
        transform.position = new Vector3(gridPos.x, 0, gridPos.z);
    }

    private void UpdateLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        string labelText = gridPos.x / gridSize + "," + gridPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = "Waypoint " + labelText;
    }
}
