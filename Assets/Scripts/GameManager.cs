using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private string gameState;
    public string gameOverScene;

    // Continue Feature
    public GameObject continueEvent;
    public int countDownMax = 10;
    private int countdownValue;
    private float cooldown=0;

    public float playerHealth;
    public Text scoreText;
    private int playerScore;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        continueEvent.SetActive(false);
        gameState = "menu";
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown >= 0) {
            cooldown -= Time.unscaledDeltaTime;
        }
        if (gameState=="continue" && Input.GetAxisRaw("Fire1") == 1)
        {
            continuing();
        }
        if (gameState=="continue" && Input.GetAxisRaw("Bomb") == 1 && cooldown < 0 )
        {
            countdownValue--;
            Text countdownTextObj = continueEvent.GetComponentsInChildren<Text>()[1];
            countdownTextObj.text = countDownMax.ToString();
            countdownTextObj.text = countdownValue.ToString();
            cooldown = 0.1f;
        }
    }

    public void triggerContinue()
    {
        Time.timeScale = 0;
        gameState = "continue";


        StartCoroutine(countdown());
    }

    private void gameOver()
    {
        gameState = "gameover";
        SceneManager.LoadScene(gameOverScene);
    }

    private void continuing()
    {
        StopAllCoroutines();
        continueEvent.SetActive(false);
        // SCORE RESET
        // INVINCIBILITY
        // RESPAWN

        Time.timeScale = 1;
        gameState = "playing";
    }

    // COROUTINE
    private IEnumerator countdown()
    {
        // Get countdown text
        Text countdownTextObj = continueEvent.GetComponentsInChildren<Text>()[1];
        countdownTextObj.text = countDownMax.ToString();

        continueEvent.SetActive(true);

        for (countdownValue = countDownMax-1; countdownValue >= 0; countdownValue--)
        {
            yield return new WaitForSecondsRealtime(1);
            countdownTextObj.text = countdownValue.ToString();
        }

        continueEvent.SetActive(false);
        Time.timeScale = 1;
        gameOver();
    }

    public void AddScore(int toAdd)
    {
        playerScore += toAdd;
        scoreText.text = playerScore.ToString("00000000");
    }
}

