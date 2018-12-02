using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

    public AudioSource alternativeSource;
    private AudioSource source;
	// Use this for initialization
	void Start () {
        source = alternativeSource != null ? alternativeSource : this.GetComponent<AudioSource>();
	}

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
