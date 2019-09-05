using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Procedurally generates a custom tetrahedron mesh
/// </summary>
[RequireComponent (typeof (MeshCollider))]
[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class TetrahedronMeshMaker : CustomMeshMaker
{
    // Generates/Regenerates tetrahedron's custom mesh
    public override void Generate()
    {
        // Retrieve object's mesh filter, warning if none exist
        MeshFilter myMeshFilter = gameObject.GetComponent<MeshFilter>();
        if (myMeshFilter == null)
        {
            Debug.Log("Warning: Tetrahedron mesh maker lacks Mesh Filter component. Adding one now.");
            myMeshFilter = gameObject.AddComponent<MeshFilter>();
        }

        // define basic vertices of tetrahedron
        Vector3 point0 = new Vector3(-0.5f, 0, -1 * Mathf.Sqrt(0.75f) / 3);
        Vector3 point1 = new Vector3(0.5f, 0, -1 * Mathf.Sqrt(0.75f) / 3);
        Vector3 point2 = new Vector3(0, 0, 2 * Mathf.Sqrt(0.75f) / 3);
        Vector3 point3 = new Vector3(0, Mathf.Sqrt(0.75f), 0);

        // retrieve or make and then refresh object's shared mesh
        if (myMeshFilter.sharedMesh == null)
            myMeshFilter.sharedMesh = new Mesh();
        Mesh myMesh = myMeshFilter.sharedMesh;
        myMesh.Clear();

        // define mesh's unique vertices
        myMesh.vertices = new Vector3[]
        {
            point0, point1, point2,
            point0, point2, point3,
            point2, point1, point3,
            point0, point3, point1
        };

        // define mesh's triangles from vertices
        myMesh.triangles = new int[]
        {
            0, 1, 2,
            3, 4, 5,
            6, 7, 8,
            9, 10, 11
        };

        // recalculate custom mesh
        myMesh.RecalculateNormals();
        myMesh.RecalculateBounds();
        myMesh.Optimize();
    }
}
