using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlanets : MonoBehaviour
{
	const int NUM_SLICES = 8;
	public int MaxHealth = 5;
	public int Health = 2;
	public float CollideRadiusMin = .8f;
	public float CollideRadiusMax = 1.25f;
	public Sprite[] DamageSprites;
	public Color DamageParticleColor;
	public Color HealParticleColor;

	void Start () {
		UpdateHealth();
	}

	void UpdateHealth () {
		var collider = GetComponent<SphereCollider>();
		collider.radius = CollideRadiusMin + (CollideRadiusMax-CollideRadiusMin)*Health/MaxHealth;

		var i = Health - 1;
		Sprite model = DamageSprites[i];
		if (model) {

			SpriteRenderer sRenderer = GetComponentInChildren<SpriteRenderer>();
			sRenderer.sprite = DamageSprites[i];
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
