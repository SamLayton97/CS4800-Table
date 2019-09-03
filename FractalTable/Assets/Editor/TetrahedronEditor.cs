using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Creates a tetrahedron object in the Unity Editor
/// </summary>
[CustomEditor (typeof (TetrahedronMeshMaker))]
public class TetrahedronEditor : Editor
{
    // Defines path to create object in editor
    [MenuItem ("GameObject/Create Custom/Tetrahedron")]

    // Called upon creation in editor
    static void Create()
    {
        // create new object with mesh components
        GameObject myObject = new GameObject("Tetrahedron");
        TetrahedronMeshMaker tetrahedronMesh = myObject.AddComponent<TetrahedronMeshMaker>();
        MeshFilter meshFilter = myObject.GetComponent<MeshFilter>();

        // generate tetrahedron mesh
        meshFilter.mesh = new Mesh();
        tetrahedronMesh.Generate();
    }
}
