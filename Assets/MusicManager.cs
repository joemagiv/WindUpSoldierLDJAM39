using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {


    private static MusicManager musicManager;


    private void Awake()
    {
        if (!musicManager)
        {
            musicManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
