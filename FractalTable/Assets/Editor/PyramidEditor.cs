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

    // Adds custom elements to components inspector GUI
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // retrieve mesh maker component, breaking 
        PyramidMeshMaker meshMaker = target as PyramidMeshMaker;
        if (meshMaker == null)
            return;

        // start custom inspector GUI stuff
        base.DrawDefaultInspector();
        EditorGUILayout.BeginHorizontal();

        // rebuild mesh when user clicks Rebuild button
        if (GUILayout.Button("Rebuild"))
            meshMaker.Generate();

        // end custom inspector GUI stuff
        EditorGUILayout.EndHorizontal();
    }
}
