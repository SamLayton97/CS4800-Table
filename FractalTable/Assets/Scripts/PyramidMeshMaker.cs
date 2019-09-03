using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Procedurally generates a custom equilateral
/// pyramid mesh
/// </summary>
[RequireComponent (typeof (MeshCollider))]
[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class PyramidMeshMaker : MonoBehaviour
{
    // TODO: Generates/regenerates pyramid's custom mesh
    public void Generate()
    {
        Debug.Log("Generate!");
    }
}
