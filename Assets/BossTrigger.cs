using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {

    private SoundManager soundManager;
    private bool playOnce;
    public AudioClip bossLaugh;

	// Use this for initialization
	void Start () {
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MainCharacter>())
        {
            if (!playOnce)
            {
                soundManager.PlaySound(bossLaugh);
                playOnce = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
