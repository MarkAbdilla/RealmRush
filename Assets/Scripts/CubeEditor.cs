using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    [Range(0.1f, 20f)]
    [SerializeField] float gridSize = 10f;

    private void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * 10f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * 10f;

        transform.position = new Vector3(snapPos.x, 0, snapPos.z);
    }

}
