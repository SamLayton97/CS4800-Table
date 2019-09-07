using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls color of children's material, forming a gradient
/// between two colors from an arbitrary point
/// </summary>
public class GradientInChildren : MonoBehaviour
{
    // public variables
    public Color fromColor = Color.white;       // color gradient transitions from
    public Color toColor = Color.black;         // color gradient transitions to
    public Vector3 startPoint;                  // relative point in 3D space to set gradient away from

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
