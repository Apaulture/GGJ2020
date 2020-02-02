using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float timer = 0;

    // Input variables
    float rotationDirection;

    // Motion control
    public float radius;
    public float rotationSpeed;
    public Transform centerTarget;

    private void Update()
    {
        rotationDirection = Input.GetAxis("Horizontal");
        timer += Time.deltaTime * rotationSpeed * -rotationDirection;
        Rotate();
        transform.LookAt(centerTarget);
    }

    void Rotate()
    {
        // Cartesian to polar coordinates transform with time-dependence
        float x = radius * Mathf.Cos(timer);
        float z = radius * Mathf.Sin(timer);

        Vector3 position = new Vector3(x, 0f, z);
        if (centerTarget) {
                transform.position = position + centerTarget.position;
        }
    }
}
