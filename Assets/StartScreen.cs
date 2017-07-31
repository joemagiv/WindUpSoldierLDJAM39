using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    public GameObject instructionsObject;
    public bool showingInstructions;

	// Use this for initialization
	void Start () {
        instructionsObject.SetActive(false);
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void ShowInstruction()
    {
        if (!showingInstructions)
        {
            instructionsObject.SetActive(true);
            showingInstructions = true;
        } else
        {
            instructionsObject.SetActive(false);
            showingInstructions = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
