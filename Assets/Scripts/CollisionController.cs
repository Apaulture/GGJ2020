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
        // Vector3 rotation = new Vector3(15, 30, 40);
        // transform.Rotate(rotation * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Meteor"))
        {
            // Play effect
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);
        }
        else if (col.gameObject.CompareTag("Arm"))
        {
            m_Rigidbody.velocity = Vector3.zero;
        }
    }
}
