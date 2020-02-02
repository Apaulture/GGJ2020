using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	const int NUM_SLICES = 8;
	public int MaxHealth = 10;
	public int Health = 5;
	public float CollideRadiusMin = .8f;
	public float CollideRadiusMax = 1.25f;
	public GameObject[] DamageModels;
	public Color DamageParticleColor = Color.red;
	public Color HealParticleColor = Color.green;
	public GameObject cam2;

	void Start () {
		UpdateHealth();
	}

	void Update() {
	}

	void UpdateHealth () {
		var collider = GetComponent<SphereCollider>();
		collider.radius = CollideRadiusMin + (CollideRadiusMax-CollideRadiusMin)*Health/MaxHealth;

		var i = Mathf.FloorToInt((-1.0f + DamageModels.Length) * Health / MaxHealth);
		GameObject model = DamageModels[i];
		if (model) {
			var meshFilter = GetComponentInChildren<MeshFilter>();
			meshFilter.mesh = model.GetComponentInChildren<MeshFilter>().sharedMesh;
		}
	}

	void EmitParticles(Color color) {
		var particles = GetComponentInChildren<ParticleSystem>();
		if (particles) {
			var emitParams = new ParticleSystem.EmitParams();
			emitParams.startColor = color;
			particles.Emit(emitParams, 100);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (Health >= MaxHealth || Health <= 0)
			return;

		if (other.gameObject.CompareTag("Meteor")) {
			--Health;
			EmitParticles(DamageParticleColor);
		} else if (other.gameObject.CompareTag("Heal")) {
			++Health;
			EmitParticles(HealParticleColor);
		}

		if (Health >= MaxHealth) {
			Health = MaxHealth;
			// Restored, victory

			cam2.SetActive(true);
		}
		if (Health <= 0) {
			Health = 0;
			var particles = GetComponentInChildren<ParticleSystem>();
			if (particles) {
				particles.transform.parent = null;
			}
			Destroy(gameObject);
			//Explode, game over
		}
		UpdateHealth();
		Destroy(other.gameObject);
	}
}
