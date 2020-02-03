using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteHealth : MonoBehaviour
{
	public static int Health = 3;
	public int MaxHealth = 3;

	void Start() {
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Meteor")) {
			Destroy(collision.gameObject);
            --Health;
            if (Health <= 0) {
				Destroy(gameObject);
			} else {
                var hud = GetComponentInChildren<HUDController>();
                if (hud)
                    hud.UpdateHealth(Health);
            }
		}
	}
}
