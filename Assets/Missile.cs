using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float missileSpeed;

    public bool headedRight;

    private Transform mainCharacterTransform;

    private SpriteRenderer spriteRenderer;

    public Sprite explosionSprite;

	// Use this for initialization
	void Start () {
        mainCharacterTransform = FindObjectOfType<MainCharacter>().GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
		
	}

    public void missileHit()
    {
        spriteRenderer.sprite = explosionSprite;
    }
	
	// Update is called once per frame
	void Update () {
		if (headedRight)
        {
            transform.Translate(new Vector3(missileSpeed, 0, 0));
        } else
        {
            transform.Translate(new Vector3((missileSpeed * -1), 0, 0));
            transform.localScale = new Vector3(-1, 1, 1);
        }
	}
}
