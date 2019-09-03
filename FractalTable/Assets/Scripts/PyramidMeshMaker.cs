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

        // Retrieve object's mesh filter, warning if none exist
        MeshFilter myMeshFilter = gameObject.GetComponent<MeshFilter>();
        if (myMeshFilter == null)
        {
            Debug.Log("Warning: Tetrahedron mesh maker lacks Mesh Filter component. Adding one now.");
            myMeshFilter = gameObject.AddComponent<MeshFilter>();
        }

        // Define vertices of pyramid
        Vector3 point0 = new Vector3(-.5f, 0, -.5f);
        Vector3 point1 = new Vector3(.5f, 0, -.5f);
        Vector3 point2 = new Vector3(.5f, 0, .5f);
        Vector3 point3 = new Vector3(-.5f, 0, .5f);
        Vector3 point4 = new Vector3(0, Mathf.Sqrt(.75f), 0);

        // retrieve or make and then refresh object's shared mesh
        if (myMeshFilter.sharedMesh == null)
            myMeshFilter.sharedMesh = new Mesh();
        Mesh myMesh = myMeshFilter.sharedMesh;
        myMesh.Clear();

        // NOTE: temporarily shares vertices
        // define mesh's unique vertices
        myMesh.vertices = new Vector3[]
        {
            point0, point1, point2, point3, point4
        };

        // define mesh's triangles from vertices
        myMesh.triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            4, 1, 0,
            4, 2, 1,
            4, 3, 2,
            0, 3, 4
        };

        // recalculate custom mesh
        myMesh.RecalculateNormals();
        myMesh.RecalculateBounds();
        myMesh.Optimize();
    }
}
