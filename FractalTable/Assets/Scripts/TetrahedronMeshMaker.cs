using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Procedurally generates a custom tetrahedron mesh
/// </summary>
[RequireComponent (typeof (MeshCollider))]
[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class TetrahedronMeshMaker : MonoBehaviour
{
    // Generates/Regenerates tetrahedron's custom mesh
    public void Generate()
    {
        // Retrieve object's mesh filter, warning if none exist
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.Log("Warning: Tetrahedron mesh maker lacks Mesh Filter component.");
            return;
        }

        // define basic vertices of tetrahedron
        Vector3 point0 = Vector3.zero;
        Vector3 point1 = Vector3.right;
        Vector3 point2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
        Vector3 point3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);

        // retrieve or make object's shared mesh

    }
}
