using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Animator enemyAnim;

    public bool isAttacking;

    public Transform bodyTransform;

    public Transform mainCharacterTransform;
    private MainCharacter mainCharacter;

    public float distanceBetweenEnemyMainCharacter;

    public GameObject missileHitGameObject;

    public float moveSpeed;

	// Use this for initialization
	void Start () {
        enemyAnim = GetComponent<Animator>();
        mainCharacterTransform = FindObjectOfType<MainCharacter>().GetComponent<Transform>();
        mainCharacter = FindObjectOfType<MainCharacter>().GetComponent<MainCharacter>();
    }


    public void bodyHit(GameObject collision)
    {
        Debug.Log("trigger detected: " + collision.gameObject.name);
        if (collision.GetComponent<Missile>())
        {
            missileHitGameObject = collision;
            enemyAnim.SetTrigger("IsHit");
        }

        if (collision.GetComponent<MainCharacter>())
        {
            enemyAnim.SetTrigger("IsHit");
            mainCharacter.health -= 10;
        }
    }

    public void DestroyThis()
    {
        Destroy(missileHitGameObject);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
        distanceBetweenEnemyMainCharacter = Vector2.Distance(bodyTransform.position, mainCharacterTransform.position);

        if (distanceBetweenEnemyMainCharacter < 3)
        {
            isAttacking = true;

        }

        if (isAttacking)
        {
            
            float step = moveSpeed * Time.deltaTime;
            enemyAnim.SetBool("IsAttacking", true);
            enemyAnim.applyRootMotion = true;
            transform.position = Vector3.MoveTowards(transform.position, mainCharacterTransform.position, step);
        }
	}
}
