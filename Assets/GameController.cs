using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int PlayerLives;

    private static GameController instanceOfGameController;


    private void Awake()
    {
        if (!instanceOfGameController)
        {
            instanceOfGameController = this;
        } else
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        
    }

    public void PlayerKilled()
    {
        PlayerLives--;
        if (PlayerLives > 0)
        {
            Invoke("RestartLevel", 2f);
        } else
        {
            UIController uiController = FindObjectOfType<UIController>().GetComponent<UIController>();
            uiController.GameOverText();
            //Put something here to restart game once you have the level
            Invoke("RestartGame", 5f);
        }
    }

    public void GameWon()
    {
        UIController uiController = FindObjectOfType<UIController>().GetComponent<UIController>();
        uiController.GameWonText();
        Invoke("RestartGame", 10f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Scene00");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
