using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its own up axis (Y-axis) at a constant speed
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}

