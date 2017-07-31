using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissileShredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BossMissile>())
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
