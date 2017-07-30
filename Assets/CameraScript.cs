using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform mainCharacter;

    public float cameraSpeed;
    public float yOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3 (mainCharacter.position.x, Mathf.Clamp(mainCharacter.position.y,0f,100f), -10f), cameraSpeed);
		
	}
}
