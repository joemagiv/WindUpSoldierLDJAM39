using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    private Rigidbody2D rb;

    public Animator treadsAnimator;
    public Animator torsoAnimator;

    public bool isJumping;

    public float currentXvelocity;
    public float currentYvelocity;

    public float maxXvelocity;

    public float moveSpeed;

    public GameObject missilePrefab;
    public GameObject gun;
    public Transform missilesParent;

    public float movementEnergy;
    public float jumpEnergy;
    public float weaponsEnergy;



	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
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

    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (movementEnergy > 0)
            {
                moveToRight();
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (movementEnergy > 0)
            {
                moveToLeft();
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
            }
        }

        if (Input.GetButtonDown("Fire"))
        {
            if (weaponsEnergy > 0)
            {
                fireGun();
            }
        }

        if (rb.velocity.y == 0)
        {
         //   isJumping = false;
        }

        currentXvelocity = rb.velocity.x;
        currentYvelocity = rb.velocity.y;


    }
		
	
}
