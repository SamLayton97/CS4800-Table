using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class of components which generate custom
/// code-based meshes.
/// </summary>
public abstract class CustomMeshMaker : MonoBehaviour
{
    // Makes custom mesh from predefined points
    public abstract void Generate();
}
