using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    float rotationDirection;

    public float rotationRate = 45.0f;

    void Update()
    {
        rotationDirection = Input.GetAxis("Mouse X") * rotationRate;
        transform.Rotate(0, rotationDirection, 0, Space.World);
    }
}
