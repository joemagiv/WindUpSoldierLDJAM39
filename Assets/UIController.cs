using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text livesText;
    public Text gamesText;

    private GameController gameController;
   

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();

    }

    public void GameOverText()
    {
        gamesText.text = "Game Over!";

    }

    public void GameWonText()
    {
        gamesText.text = "You've Defeated the Bat-Bot King! \n Thanks for playing!";
    }

    // Update is called once per frame
    void Update () {
        livesText.text = "x " + gameController.PlayerLives.ToString();
	}
}
