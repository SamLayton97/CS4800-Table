using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates a sierpinski tetrahedron using this object's 
/// child tetrahedron object as its base
/// </summary>
public class SierpinskiTetrahedronGenerator : MonoBehaviour
{
    // public variables
    [SerializeField] float precision = 0.1f;        // level of detail generation continues to until it stops
    [SerializeField] GameObject baseTetrahedron;

    // Start is called before the first frame update
    void Start()
    {
        // if base tetrahedron wasn't set before startup
        if (baseTetrahedron == null)
        {
            // assume first child object is base tetrahedron and retrieve it
            try
            {
                baseTetrahedron = transform.GetChild(0).gameObject;
            }
            // print error message and break if no child fractal base
            catch
            {
                Debug.Log("Error: No base object to generate Sierpinski tetrahedron from!");
                return;
            }
        }

        // Generate Sierpinski tetrahedron from base tetrahedron
        GenerateSierpinskiTetrahedron(baseTetrahedron.transform);
    }

    /// <summary>
    /// Recursively generates a Sierpinski tetrahedron from 
    /// a basic starting object.
    /// </summary>
    /// <param name="toBreak">tetrahedron to "break" with next generation</param>
    void GenerateSierpinskiTetrahedron(Transform toBreak)
    {
        // if scale of next generation doesn't exceed fractal's level of precision, continue generation
        float newScale = toBreak.localScale.x / 2;
        if (newScale > precision)
        {
            // scale current tetrahedron
            toBreak.localScale *= .5f;

            // duplicate/reposition tetrahedrons to form next generation of fractal
            // Note: Duplicate tetrahedrons are instantiated as children of whole
            // fractal for easy manipulation.
            Instantiate(toBreak.gameObject, gameObject.transform).transform.localPosition +=
                new Vector3(newScale * .5f, 0, newScale * Mathf.Sqrt(.75f) / -3);
            Instantiate(toBreak.gameObject, gameObject.transform).transform.localPosition +=
                new Vector3(0, 0, newScale * 2 * Mathf.Sqrt(.75f) / 3);
            Instantiate(toBreak.gameObject, gameObject.transform).transform.localPosition +=
                new Vector3(0, newScale * Mathf.Sqrt(.75f), 0);
            toBreak.localPosition += new Vector3(newScale * -.5f, 0, newScale * Mathf.Sqrt(.75f) / -3);

            // start generation with "broken" child objects of entire fractal
            for (int nextToBreak = 0; nextToBreak < gameObject.transform.childCount; nextToBreak++)
                GenerateSierpinskiTetrahedron(gameObject.transform.GetChild(nextToBreak));
        }
    }
}
