using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource audioSource;
    public bool isPlaying;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (audioSource.isPlaying)
        {
            isPlaying = true;
        } else
        {
            isPlaying = false;
        }
	}
}
