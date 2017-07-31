using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    public bool isAlive;

    private Rigidbody2D rb;

    public Animator treadsAnimator;
    public Animator torsoAnimator;

    public bool isJumping;

    public float maxXvelocity;

    public float moveSpeed;

    public GameObject missilePrefab;
    public GameObject gun;
    public Transform missilesParent;

    public float movementEnergy;
    public float jumpEnergy;
    public float weaponsEnergy;

    public int health;
    public Transform healthBarTransform;

    public SpriteRenderer spriteRenderer;
    public Sprite explosionSprite;

    private GameController gameController;

    private SoundManager soundManager;
    public AudioClip errorSound;
    public AudioClip explosionSound;
    public AudioClip pewSound;
    public AudioClip jumpSound;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    private void moveToRight()
    {
        transform.Translate(new Vector3 (moveSpeed, 0, 0));

        startMoving();
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void moveToLeft()
    {
        transform.Translate(new Vector3((moveSpeed * -1), 0, 0));

        startMoving();
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public float jumpHeight;

    private void jump()
    {
        isJumping = true;

        if (jumpEnergy > 60)
        {
            jumpEnergy -= 60;
        }
        else
        {
            jumpEnergy = 0;
        }
        rb.AddForceAtPosition(new Vector2(0, jumpHeight),transform.position, ForceMode2D.Impulse);
        soundManager.PlaySound(jumpSound);

    }

    private void fireGun()
    {
        if (weaponsEnergy > 60) { 
        weaponsEnergy -= 60;
        } else
        {
            weaponsEnergy = 0;
        }
        torsoAnimator.SetTrigger("Fire");
        GameObject missile = Instantiate(missilePrefab, gun.transform.position, Quaternion.identity, missilesParent);
        Missile missileScript = missile.GetComponent<Missile>();
        soundManager.PlaySound(pewSound);
        if (transform.localScale.x == 1)
        {
            missileScript.headedRight = true;
        }
    }

    private void startMoving()
    {
        treadsAnimator.SetBool("isMoving", true);
        torsoAnimator.SetBool("isMoving", true);
    }

    private void stopMoving()
    {
        treadsAnimator.SetBool("isMoving", false);
        torsoAnimator.SetBool("isMoving", false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        isJumping = false;

    }

    private void killPlayer()
    {
        torsoAnimator.enabled = false;
        spriteRenderer.sprite = explosionSprite;
        gameController.PlayerKilled();
    }

    private void playErrorSound()
    {
        if (!soundManager.isPlaying)
        {
            soundManager.PlaySound(errorSound);
        }
    }

    // Update is called once per frame
    void Update () {
        healthBarTransform.localScale = new Vector3(health / 100f, 1f, 1f);

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (movementEnergy > 0)
            {
                moveToRight();
            } else
            {
                playErrorSound();
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (movementEnergy > 0)
            {
                moveToLeft();
            } else
            {
                playErrorSound();
            }
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            stopMoving();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                if (jumpEnergy > 0)
                {
                    jump();
                }
                else
                {
                    playErrorSound();
                }
            }
        }

        if (Input.GetButtonDown("Fire"))
        {
            if (weaponsEnergy > 0)
            {
                fireGun();
                
            }
            else
            {
                playErrorSound();
            }
        }

        if (rb.velocity.y == 0)
        {
         //   isJumping = false;
        }


        if (isAlive)
        {
            if (health <= 0)
            {
                isAlive = false;
                killPlayer();
            }
        }
    }

    
		
	
}
