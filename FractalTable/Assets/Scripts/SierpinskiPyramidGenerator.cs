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
    List<GameObject> pyramids;

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

        // instantiate list containing all pyramid sub-objects in fractal and add base pyramid
        pyramids = new List<GameObject>();
        pyramids.Add(basePyramid);

        // generate sierpinski pyramid
        GenerateSierpinskiPyramid(pyramids);
    }

    void GenerateSierpinskiPyramid(List<GameObject> toBreak)
    {
        // create a list storing pyramids "broken" during generation
        List<GameObject> brokenPyramids = new List<GameObject>();

        // for each triangle not yet broken by current generation
        foreach (GameObject pyramid in toBreak)
        {
            // scale pyramid by .5
            pyramid.transform.localScale *= .5f;
        }
    }
}
