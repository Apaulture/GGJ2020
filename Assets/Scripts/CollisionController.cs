using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Renderer m_Renderer;

    float holdTimer;
    bool touched = false;
    bool held = false;

    public Color32 damageMeteor;
    public Color32 healMeteor;
    public float holdThreshold; // Time held before turning into a healing meteor

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Renderer = GetComponent<Renderer>();

        if (gameObject.CompareTag("Meteor"))
        {
            m_Renderer.material.SetColor("_Color", damageMeteor);
            m_Renderer.material.SetColor("_EmissionColor", Color.black);
        }
        
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

        // Condition to turn meteor into healing object
        if (touched && transform.parent)
        {
            holdTimer += Time.deltaTime;

            if (holdTimer > holdThreshold)
            {
                held = true;

                if (held)
                {
                    m_Renderer.material.SetColor("_Color", healMeteor);
                    m_Renderer.material.SetColor("_EmissionColor", healMeteor);
                    gameObject.tag = "Heal";
                }
            }
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
            // On collision with arm
            m_Rigidbody.velocity = Vector3.zero;
            transform.parent = col.gameObject.transform;

            touched = true;
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            // Game over

            // Play satellite destruction animation
        }
    }
}
