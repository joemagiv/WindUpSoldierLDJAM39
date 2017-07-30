using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour {

    private Enemy enemy;

	// Use this for initialization
	void Start () {
        enemy = GetComponentInParent<Enemy>();
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.bodyHit(collision.gameObject);
    }

        // Update is called once per frame
        void Update () {
		
	}
}
