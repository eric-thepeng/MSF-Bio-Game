using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    float rotationSpeed = 30f; // Speed of the rotation, in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Rotate the GameObject around the Y-axis at a given speed per second
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
