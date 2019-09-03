using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates a sierpinski pyramid using this object's 
/// child pyramid object as its base
/// </summary>
public class SierpinskiPyramidGenerator : MonoBehaviour
{
    // public variables
    [SerializeField] GameObject basePyramid;

    // Start is called before the first frame update
    void Start()
    {
        // if base pyramid wasn't set before startup
        if (basePyramid == null)
        {
            // assume first child object is base pyramid and retrieve it
            try
            {
                basePyramid = transform.GetChild(0).gameObject;
            }
            // print error message and break if no child was found
            catch
            {
                Debug.Log("Error: No base object to generate Sierpinski pyramid from!");
                return;
            }
        }


    }
}
