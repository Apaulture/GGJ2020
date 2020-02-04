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

    public AudioClip[] HitOtherMeteorSounds;
    public AudioClip[] HitSatelliteSounds;
    public AudioClip[] HitPlanetSounds;
    public AudioClip LaunchSound;
    public AudioClip ChangeSound;
    public AudioClip HealSound;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Renderer = GetComponentInChildren<Renderer>();

        if (gameObject.CompareTag("Meteor"))
        {
            m_Renderer.material.SetColor("_Color", damageMeteor);
            m_Renderer.material.SetColor("_EmissionColor", Color.black);
        }
        
    }

    void Update()
    {
        Vector3 rotation = new Vector3(0, 30, 0);
        transform.Rotate(rotation * Time.deltaTime);

	var meteorController = GameObject.FindObjectOfType<MeteorController>();
        bool isGrabbed = transform.parent
                && transform.parent.CompareTag("Arm");
        if (isGrabbed && Input.GetAxis("Fire1") == 1)
        {
            // The direction of the meteor after you let go of it
            var cannon = transform.parent.GetComponent<CannonMovement>();
            m_Rigidbody.velocity = transform.parent.rotation * Vector3.forward * cannon.ThrowMeteorSpeed;

            // Change the parent of the meteor so it doesn't follow the path when you rotate the arm
            this.transform.parent = null;

            var audio = GetComponentInChildren<AudioSource>();
            audio.clip = LaunchSound;
            audio.Play();
	    if (meteorController) {
		    meteorController.StartMeteors();
	    }
        }

        // Condition to turn meteor into healing object
        if (touched && transform.parent)
        {
            holdTimer += Time.deltaTime;

            if (holdTimer > holdThreshold)
            {
                if (!held)
                {
                    var audio = GetComponentInChildren<AudioSource>();
                    audio.clip = ChangeSound;
                    audio.Play();
		    var tutorialText = GameObject.FindObjectOfType<TutorialText>();
		    if (tutorialText) {
			    if (meteorController && !meteorController.started)
				    tutorialText.SetText("RIGHT TRACKPAD L/R: ROTATE SHIP\nRIGHT TRIGGER: THROW HEALING ROCK\nAT THE PLANET TO RESTORE");
			    else
				    tutorialText.SetText("");
		    }
                }
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

    public void PlayRandomSound(AudioClip[] soundSet)
    {
        var audio = GetComponentInChildren<AudioSource>();
        if (audio)
        {
            var clip = soundSet[Random.Range(0, soundSet.Length - 1)];
            if (clip)
            {
                audio.clip = clip;
                audio.Play();
            }
        }
    }

    private void DoDestroyEffects() {
        var particles = GetComponentInChildren<ParticleSystem>();
        if (particles)
        {
            particles.transform.SetParent(null, true);
            var emitParams = new ParticleSystem.EmitParams();
            Color color = held ? healMeteor : damageMeteor;
            emitParams.startColor = color;
            particles.Emit(emitParams, 100);
        }
        var meteorController = GameObject.FindObjectOfType<MeteorController>();
        var tutorialText = GameObject.FindObjectOfType<TutorialText>();
        var audio = GetComponentInChildren<AudioSource>();

        if (audio)
                audio.transform.SetParent(null, true);

        if (meteorController) {
                meteorController.StartMeteors();
        }
        if (tutorialText)
                tutorialText.SetText("");
    }

    private void OnCollisionEnter(Collision col)
    {
        var meteorController = GameObject.FindObjectOfType<MeteorController>();
        var tutorialText = GameObject.FindObjectOfType<TutorialText>();
        var audio = GetComponentInChildren<AudioSource>();
        if (col.gameObject.CompareTag("Meteor"))
        {
            PlayRandomSound(HitOtherMeteorSounds);
            DoDestroyEffects();
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Heal"))
        {
            /*if (CompareTag("Heal"))
            {
                // TODO pass through
            }
            else*/
            {
                DoDestroyEffects();
                Destroy(gameObject);
            }
        }
        else if (col.gameObject.CompareTag("Arm"))
        {
            // On collision with arm
            m_Rigidbody.velocity = Vector3.zero;
            transform.parent = col.gameObject.transform;

	    if (tutorialText && !touched) {
                    if (meteorController && !meteorController.started)
                            tutorialText.SetText("CONVERTING TO HEALING ROCK...");
	    }
            touched = true;
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            PlayRandomSound(HitSatelliteSounds);
            DoDestroyEffects();
            Destroy(gameObject);
        }
        else if (col.gameObject.GetComponent<Planet>())
        {
            if (held)
            {
                audio.PlayOneShot(HealSound);
            }
            else
            {
                PlayRandomSound(HitPlanetSounds);
            }
            DoDestroyEffects();
            Destroy(gameObject);
        }
    }
}
