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
    [SerializeField] float precision = 0.1f;       // level of detail generation continues to until it stops
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

        // generate sierpinski pyramid from base pyramid
        GenerateSierpinskiPyramid(basePyramid.transform);
    }

    /// <summary>
    /// Recursively generates a Sierpinski pyramid from 
    /// a basic starting pyramid.
    /// </summary>
    /// <param name="toBreak">pyramid to break with next generation</param>
    void GenerateSierpinskiPyramid(Transform toBreak)
    {
        // if scale of next generation doesn't exceed fractal's level of precision, continue generation
        float newScale = toBreak.localScale.x / 2;
        if (newScale > precision)
        {
            // scale current pyramid
            toBreak.localScale *= .5f;

            // duplicate/reposition pyramids to form next generation of fractal
            // Note: Duplicate pyramids are instantiated as children of whole
            // fractal for easy manipulation.
            toBreak.localPosition += new Vector3(-.5f, 0, -.5f) * toBreak.localScale.x;
            Instantiate(toBreak.gameObject, gameObject.transform).transform.localPosition += new Vector3(newScale, 0, newScale);
            Instantiate(toBreak.gameObject, gameObject.transform).transform.localPosition += new Vector3(newScale, 0, 0);
            Instantiate(toBreak.gameObject, gameObject.transform).transform.localPosition += new Vector3(0, 0, newScale);
            Instantiate(toBreak.gameObject, gameObject.transform).transform.localPosition +=
                new Vector3(newScale / 2, newScale * Mathf.Sqrt(.75f), newScale / 2);

            // start generation with "broken" child pyramids of entire fractal
            for (int nextToBreak = 0; nextToBreak < gameObject.transform.childCount; nextToBreak++)
                GenerateSierpinskiPyramid(gameObject.transform.GetChild(nextToBreak));
        }
    }
}
