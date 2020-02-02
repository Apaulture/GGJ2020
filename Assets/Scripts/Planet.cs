using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	const int NUM_SLICES = 8;
	public int MaxHealth = 10;
	public int Health = 5;
	public float ScalePerHealth = .25f;
	public GameObject[] DamageModels;

	void Start () {
		UpdateHealth();
	}

	void Update() {
	}

	void UpdateHealth () {
		var scale = transform.localScale;
		scale.x = scale.y = scale.z = ScalePerHealth * Health;
		//transform.localScale = scale;
		var i = Mathf.FloorToInt((-1.0f + DamageModels.Length) * Health / MaxHealth);
		GameObject model = DamageModels[i];
		if (model) {
			var meshFilter = GetComponentInChildren<MeshFilter>();
			meshFilter.mesh = model.GetComponentInChildren<MeshFilter>().sharedMesh;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (Health >= MaxHealth || Health <= 0)
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
		if (Health <= 0) {
			Health = 0;
			Destroy(gameObject);
			//Explode, game over
		}
		UpdateHealth();
		Destroy(other.gameObject);
	}
}
