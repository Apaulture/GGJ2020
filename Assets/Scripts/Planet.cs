using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	const int NUM_SLICES = 8;
	public int MaxHealth = 10;
	public int Health = 5;
	public float ScalePerHealth = .25f;

	void Start () {
		SetScale(Health*ScalePerHealth);
	}

	void Update() {
	}

	void SetScale (float s) {
		var scale = transform.localScale;
		scale.x = scale.y = scale.z = s;
		transform.localScale = scale;
	}

	void OnCollisionEnter(Collision other) {
		if (Health >= MaxHealth)
			return;

		if (other.gameObject.tag == "Meteor") {
			--Health;
		} else /*TODO tag for healing object if needed*/ {
			++Health;
		}
		if (Health >= MaxHealth) {
			Health = MaxHealth;
			// Restored, victory
		}
		SetScale(Health * ScalePerHealth);
		if (Health <= 0) {
			Destroy(gameObject);
			//Explode, game over
		}
		Destroy(other.gameObject);
	}
}
