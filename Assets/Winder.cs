using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winder : MonoBehaviour {

    public bool isMovementWinder;
    public bool isJumpingWinder;
    public bool isWeaponsWinder;

    public Transform winderKey;

    public Transform frontClock;

    private MainCharacter mainCharacter;

    public Sprite keySpriteIdle;
    public Sprite keySpriteTurning;

    public Image keyImage;

    private float currentKeyRotation;

    public bool isTurning;
    public float timeSinceTurningStopped;
    public float timeToStop;

    public float energyDecay;


	// Use this for initialization
	void Start () {
        mainCharacter = FindObjectOfType<MainCharacter>().GetComponent<MainCharacter>();
	}

    public void detectMouseover()
    {
        //Debug.Log("Detected Mouseover");
    }

    public void IncreaseMovementEnergy()
    {
        if (mainCharacter.movementEnergy < 600)
        {
            isTurning = true;
            timeSinceTurningStopped = 0;
            if (mainCharacter.movementEnergy < 500)
            {
                mainCharacter.movementEnergy += 100;
            } else { 
                mainCharacter.movementEnergy = 600;
            }
            keyImage.sprite = keySpriteTurning;
            currentKeyRotation += 40;
            winderKey.transform.rotation = Quaternion.Euler(0, 0, currentKeyRotation);
        }
    }

    public void IncreaseJumpingEnergy()
    {
        if (mainCharacter.jumpEnergy < 600)
        {
            isTurning = true;
            timeSinceTurningStopped = 0;
            if (mainCharacter.jumpEnergy < 500)
            {
                mainCharacter.jumpEnergy += 100;
            }
            else
            {
                mainCharacter.jumpEnergy = 600;
            }
            keyImage.sprite = keySpriteTurning;
            currentKeyRotation += 40;
            winderKey.transform.rotation = Quaternion.Euler(0, 0, currentKeyRotation);
        }
    }

    public void IncreaseWeaponsEnergy()
    {
        if (mainCharacter.weaponsEnergy < 600)
        {
            isTurning = true;
            timeSinceTurningStopped = 0;
            if (mainCharacter.weaponsEnergy < 500)
            {
                mainCharacter.weaponsEnergy += 100;
            }
            else
            {
                mainCharacter.weaponsEnergy = 600;
            }
            keyImage.sprite = keySpriteTurning;
            currentKeyRotation += 40;
            winderKey.transform.rotation = Quaternion.Euler(0, 0, currentKeyRotation);
        }
    }


    // Update is called once per frame
    void Update () {
		if (isTurning)
        {
            timeSinceTurningStopped += Time.deltaTime;
            if (timeSinceTurningStopped > timeToStop)
            {
                keyImage.sprite = keySpriteIdle;
                currentKeyRotation = 0;
                isTurning = false;
                winderKey.transform.rotation = Quaternion.Euler(0, 0, 0);
                timeSinceTurningStopped = 0;

            }
        }


        if (isMovementWinder)
        {
            frontClock.transform.rotation = Quaternion.Euler(0, 0, 360 * (mainCharacter.movementEnergy / 600));
            if (mainCharacter.movementEnergy > 0)
            {
                mainCharacter.movementEnergy -= energyDecay;
            }
        }

        if (isJumpingWinder)
        {
            frontClock.transform.rotation = Quaternion.Euler(0, 0, 360 * (mainCharacter.jumpEnergy / 600));
            if (mainCharacter.jumpEnergy > 0)
            {
                mainCharacter.jumpEnergy -= energyDecay;
            }
        }

        if (isWeaponsWinder)
        {
            frontClock.transform.rotation = Quaternion.Euler(0, 0, 360 * (mainCharacter.weaponsEnergy / 600));
            if (mainCharacter.weaponsEnergy > 0)
            {
                mainCharacter.weaponsEnergy -= energyDecay;
            }
        }
    }
}
