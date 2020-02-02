using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 rotation = new Vector3(15, 30, 40);
        transform.Rotate(rotation * Time.deltaTime);

        bool isGrabbed = transform.parent
                && transform.parent.CompareTag("Arm");
        if (isGrabbed && Input.GetAxis("Fire1") == 1)
        {
            // The direction of the meteor after you let go of it
            var cannon = transform.parent.GetComponent<CannonMovement>();
            m_Rigidbody.velocity = transform.parent.rotation * Vector3.forward * cannon.ThrowMeteorSpeed;

            // Change the parent of the meteor so it doesn't follow the path when you rotate the arm
            this.transform.parent = null;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Meteor"))
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Arm"))
        {
            m_Rigidbody.velocity = Vector3.zero;
            transform.parent = col.gameObject.transform;
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            // Game over

            // Play satellite destruction animation
        }
    }
}
