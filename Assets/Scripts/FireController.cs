using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        float fire1 = Input.GetAxis("Fire1");

        if (fire1 == 1)
        {
            Vector3 cannonPosition = transform.position;
            Vector3 cannonOffset = new Vector3(0, 0, 0.5f);

            Instantiate(bullet, cannonPosition + cannonOffset, Quaternion.identity, transform.parent.parent);
            
        }
    }
}
