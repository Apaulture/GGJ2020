using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public GameObject arm;

    public static bool holdingMeteor;

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

        if (holdingMeteor && Input.GetAxis("Fire1") == 1)
        {
            Vector3 velocity = new Vector3(1, 0, 1);
            m_Rigidbody.velocity = velocity;
            this.transform.parent.parent = this.transform;
        }
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
            transform.parent = col.gameObject.transform;
            holdingMeteor = true;
        }
    }
}
