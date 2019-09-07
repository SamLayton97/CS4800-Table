using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls color of children's material, forming a gradient
/// between two colors away from an arbitrary point
/// </summary>
public class GradientInChildren : MonoBehaviour
{
    // public variables
    public Color fromColor = Color.white;       // color gradient transitions from
    public Color toColor = Color.black;         // color gradient transitions to
    public Vector3 startPoint;                  // local point in 3D space to set gradient away from
    public float radius;                        // distance to end of gradient

    // Start is called before the first frame update
    void Start()
    {
        // iterate over this object's children
        for (int currChild = 0; currChild < transform.childCount; currChild++)
        {
            // find distance from local start point to current child
            Transform childTransform = transform.GetChild(currChild);
            float distFromPoint = Vector3.Distance(childTransform.localPosition, startPoint);

            // lerp color of current child according to distance from point
            Renderer childRend = childTransform.gameObject.GetComponent<Renderer>();
            childRend.material.SetColor("_Color", Color.Lerp(fromColor, toColor, distFromPoint / radius));
        }
    }
}
