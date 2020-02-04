using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	public AudioClip WinMusic;
	public AudioClip LoseMusic;

	public void Play(AudioClip clip) {
		var audio = GetComponent<AudioSource>();
		audio.clip = clip;
		audio.Play();
	}
}
