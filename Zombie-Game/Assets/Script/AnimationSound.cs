using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AnimationSound : MonoBehaviour {

	AudioSource AS;

	void Start () {
		AS = GetComponent<AudioSource>();
	}
	
	void PlaySound (AudioClip sound) {
		AS.PlayOneShot(sound);
	}
}
