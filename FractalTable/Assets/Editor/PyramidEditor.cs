using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Creates an equilateral pyramid object in the Unity editor
/// </summary>
[CustomEditor (typeof(PyramidMeshMaker))]
public class PyramidEditor : Editor
{
    // Defines path to create object in editor
    [MenuItem ("GameObject/Custom/Pyramid")]

    // Called upon creation in editor
    static void Create()
    {
        // create new object with appropriate components
        GameObject self = new GameObject("Pyramid");
        PyramidMeshMaker pyramidMesh = self.AddComponent<PyramidMeshMaker>();
        MeshFilter meshFilter = self.GetComponent<MeshFilter>();

        // generate pyramid mesh
        meshFilter.mesh = new Mesh();
        pyramidMesh.Generate();
    }
}
