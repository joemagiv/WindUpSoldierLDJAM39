using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour {

    public bool isFiring;

    public GameObject bossMissilePrefab;

    public float nextFire;
    public float currentFireTimer;

    public Transform bossMissilesParent;

	// Use this for initialization
	void Start () {
        isFiring = true;
	}

    public void FireMissile()
    {
        if (isFiring)
        {
            GameObject bossMissile = Instantiate(bossMissilePrefab, transform.position, transform.rotation, bossMissilesParent);
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentFireTimer += Time.deltaTime;
        if (currentFireTimer > nextFire)
        {
            FireMissile();
            currentFireTimer = 0;
        }
	}
}
