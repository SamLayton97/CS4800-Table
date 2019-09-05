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
public class PyramidMeshMaker : CustomMeshMaker
{
    /// <summary>
    /// Property with read-access to vertices defining pyramid
    /// </summary>
    public Vector3[] Points
    {
        get {
            return new Vector3[] 
            {
            new Vector3(-.5f, 0, -.5f),             // bottom left base point
            new Vector3(.5f, 0, -.5f),              // bottom right base point
            new Vector3(.5f, 0, .5f),               // top right base point
            new Vector3(-.5f, 0, .5f),              // top left base point
            new Vector3(0, Mathf.Sqrt(.75f), 0)     // peak of pyramid; 
            };
        }
    }

    /// <summary>
    /// Generates/regenerates pyramid's custom mesh
    /// </summary>
    public override void Generate()
    {
        // Retrieve object's mesh filter, warning if none exist
        MeshFilter myMeshFilter = gameObject.GetComponent<MeshFilter>();
        if (myMeshFilter == null)
        {
            Debug.Log("Warning: Pyramid Mesh Maker lacks Mesh Filter component. Adding component now.");
            myMeshFilter = gameObject.AddComponent<MeshFilter>();
        }

        // retrieve or make and then refresh object's shared mesh
        if (myMeshFilter.sharedMesh == null)
            myMeshFilter.sharedMesh = new Mesh();
        Mesh myMesh = myMeshFilter.sharedMesh;
        myMesh.Clear();

        // define mesh's unique vertices
        myMesh.vertices = new Vector3[]
        {
            Points[0], Points[1], Points[2],
            Points[0], Points[2], Points[3],
            Points[4], Points[1], Points[0],
            Points[4], Points[2], Points[1],
            Points[4], Points[3], Points[2],
            Points[0], Points[3], Points[4]
        };

        // define mesh's triangles from vertices
        myMesh.triangles = new int[]
        {
            0, 1, 2,
            3, 4, 5,
            6, 7, 8,
            9, 10, 11,
            12, 13, 14,
            15, 16, 17
        };

        // recalculate custom mesh
        myMesh.RecalculateNormals();
        myMesh.RecalculateBounds();
        myMesh.Optimize();
    }
}
