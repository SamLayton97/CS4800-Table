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
        // if scale of next generation doesn't exceed fractal's level of precision, continue generation
        float newScale = toBreak[0].transform.localScale.x / 2;
        if (newScale > precision)
        {
            // for each triangle not yet broken by current generation
            foreach (GameObject currPyramid in toBreak)
            {
                // scale current pyramid
                currPyramid.transform.localScale *= .5f;

                // duplicate/reposition pyramids to form new generation of fractal
                // Note: Duplicate pyramids are instantiated as children of whole
                // fractal for easy manipulation.
                currPyramid.transform.localPosition += new Vector3(-.5f, 0, -.5f) * currPyramid.transform.localScale.x;
                Instantiate(currPyramid, gameObject.transform).transform.localPosition += new Vector3(newScale, 0, newScale);
                Instantiate(currPyramid, gameObject.transform).transform.localPosition += new Vector3(newScale, 0, 0);
                Instantiate(currPyramid, gameObject.transform).transform.localPosition += new Vector3(0, 0, newScale);
                Instantiate(currPyramid, gameObject.transform).transform.localPosition += 
                    new Vector3(newScale / 2, newScale * Mathf.Sqrt(.75f), newScale / 2);
            }
        }
    }
}
