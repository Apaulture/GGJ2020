using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource mySound;
    public AudioClip soundFX;
    public AudioClip clickFX;

    public void HoverSound()
    {
        mySound.PlayOneShot(soundFX);
    }
    public void ClickSound()
    {
        mySound.PlayOneShot(clickFX);
    }
}