using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour {

    public float missileSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Sprite explosionImage;
    private bool isMoving = true;
    private SoundManager soundManager;
    public AudioClip explosionSound;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<MainCharacter>())
        {
            isMoving = false;
            spriteRenderer.sprite = explosionImage;
            MainCharacter mainCharacterScript = collision.gameObject.GetComponent<MainCharacter>();
            mainCharacterScript.health -= 10;
            transform.localScale = new Vector3(1, 1, 1);
            soundManager.PlaySound(explosionSound);
            Invoke("DestroySelf", 0.15f);
        }
    }


    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            rb.velocity = (transform.right * missileSpeed);
        }
        
    }
}
