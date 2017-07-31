using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBody : MonoBehaviour {

    public bool isAlive;

    public float bossHealth;
    public float maxBossHealth;
    public bool isHit;
    public Sprite explosionSprite;
    private SpriteRenderer bodySpriteRenderer;
    private GameObject missileObject;
    private Color startingColor;
    
    public Transform healthBar;

    private GameController gameController;

    private SoundManager soundManager;
    public AudioClip bossHitSound;
    public AudioClip explosionVictory;

	// Use this for initialization
	void Start () {
        bodySpriteRenderer = GetComponent<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();

        startingColor = bodySpriteRenderer.color;
        bossHealth = maxBossHealth;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Missile>())
        {
            if (!isHit)
            {
                bossHealth -= 5;
                float remainingBossHealthPercentage = (bossHealth / maxBossHealth);
                healthBar.localScale = new Vector3 ((remainingBossHealthPercentage),1f,1f);
                bodySpriteRenderer.color = Color.red;
                missileObject = collision.gameObject;
                isHit = true;
                SpriteRenderer missilesSpriteRenderer = missileObject.GetComponent<SpriteRenderer>();
                missilesSpriteRenderer.sprite = explosionSprite;
                Invoke("DestroyMissile", 0.15f);
                soundManager.PlaySound(bossHitSound);
            }
            
        }
    }

    private void DestroyMissile()
    {
        Destroy(missileObject);
        isHit = false;
        bodySpriteRenderer.color = startingColor;
    }

    private void BossKilled()
    {
        Animator bossAnimator = GetComponentInParent<Animator>();
        bossAnimator.enabled = false;
        bodySpriteRenderer.sprite = explosionSprite;
        gameController.GameWon();
        soundManager.PlaySound(explosionVictory);

        BossGun[] guns = FindObjectsOfType<BossGun>();
        foreach (BossGun gun in guns)
        {
            gun.isFiring = false;
        }
    }



    // Update is called once per frame
    void Update () {

        if (isAlive)
        {
            if (bossHealth <= 0)
            {
                isAlive = false;
                BossKilled();
                
            }
        }
		
	}
}
