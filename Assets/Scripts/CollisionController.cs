using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rotation = new Vector3(15, 30, 40);
        //transform.Rotate(rotation * Time.deltaTime);

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
            // Play effect
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Arm"))
        {
            m_Rigidbody.velocity = Vector3.zero;
            transform.parent = col.gameObject.transform;
        }
    }
}
