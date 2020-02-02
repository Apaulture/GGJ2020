using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteHealth : MonoBehaviour
{
	public int MaxHealth = 3;

	public int Health = 3;

	void Start() {
		Health = MaxHealth;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Meteor")) {
			Destroy(collision.gameObject);
			if (--Health <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
