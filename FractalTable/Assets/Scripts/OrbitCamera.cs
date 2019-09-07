using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enables user to rotate camera around an object
/// using their mouse
/// </summary>
public class OrbitCamera : MonoBehaviour
{
    // public variables
    public Transform targetTransform;
    public Vector3 lookOffset;
    public float orbitSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // set camera to start facing object plus offset
        transform.LookAt(targetTransform);
        //transform.Rotate(lookOffset);
    }

    // Update is called once per frame
    void Update()
    {
        // rotate camera around object's y-axis using "Mouse X" input
        transform.RotateAround(targetTransform.position, Vector3.down, Input.GetAxis("Mouse X") * Time.deltaTime * orbitSpeed);

        Debug.Log("Mouse X: " + Input.GetAxis("Mouse X"));
        //Debug.Log("Mouse Y: " + Input.GetAxis("Mouse Y"));
    }
}
