using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int playerScore;
    public string gameState;
    private GameObject continueEvent;
    private GameObject levelLoader;
    private bool loadLevel = true;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        InitLevel();
    }

    private void Update() {
        if(loadLevel == true) {
            {
                levelLoader =  GameObject.FindGameObjectsWithTag("load")[0];
                continueEvent =  GameObject.FindGameObjectsWithTag("continue")[0];
                continueEvent.SetActive(false);
                levelLoader.BroadcastMessage("PrepareToStart");
                loadLevel = false;
            }
        }
    }

    public void InitLevel()
    {
        loadLevel = true;
        gameState = "initGame";
    }

    public void ChangeLevel()
    {
        levelLoader.BroadcastMessage("ChangeLevel", SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TriggerContinue()
    {
        Time.timeScale = 0;
        gameState = "continue";
        continueEvent.SetActive(true);
        continueEvent.BroadcastMessage("StartCountdown");
    }

    public void RestartGame()
    {
        continueEvent.SetActive(false);
        playerScore = 0;
        GameObject.FindGameObjectsWithTag("player")[0].BroadcastMessage("Respawn");
        Time.timeScale = 1;
        gameState = "playing";
    }

    public void GameOver()
    {
        gameState = "gameOver";
        SceneManager.LoadScene("GameOver");
        Destroy(this.gameObject);
    }

}

