using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour {

    private GameController gameController;
    private SoundManager soundManager;
    public AudioClip falling;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MainCharacter>())
        {
            soundManager.PlaySound(falling);
            Invoke("KillPlayer", 2f);
        }
    }

    private void KillPlayer()
    {
        gameController.PlayerKilled();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
