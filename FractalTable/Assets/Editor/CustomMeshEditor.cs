using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Controls basic editor functionality of custom code-generated meshes
/// </summary>
public class CustomMeshEditor : Editor
{
    // Adds custom elements to components inspector GUI
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // retrieve mesh maker component, breaking if none found
        CustomMeshMaker meshMaker = target as CustomMeshMaker;
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
