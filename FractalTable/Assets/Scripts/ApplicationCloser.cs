using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Closes application on user input (ESC by default)
/// </summary>
public class ApplicationCloser : MonoBehaviour
{
    // Called once per frame
    void Update()
    {
        // close application when user presses quit button
        if (Input.GetAxisRaw("Quit") != 0)
            Application.Quit();
    }
}
