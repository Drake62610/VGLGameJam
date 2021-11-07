using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    public Text countdownTextObj;
    public int countDownMax = 10;
    private int countdownValue;

    private bool restartKeyReleased = false;
    private bool decrementCountdownKeyReleased = false;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState == "continue")
        {
            if (Input.GetAxisRaw("Fire1") == 1 && restartKeyReleased)
            {
                Continuing();
            }
            if (Input.GetAxisRaw("Bomb") == 1 && decrementCountdownKeyReleased)
            {
                countdownValue--;
                countdownTextObj.text = Math.Max(countdownValue, 0).ToString();
            }

            restartKeyReleased = Input.GetAxisRaw("Fire1") == 0;
            decrementCountdownKeyReleased = Input.GetAxisRaw("Bomb") == 0;
        }

    }

    public void StartCountdown()
    {
        restartKeyReleased = false;
        decrementCountdownKeyReleased = false;
        StartCoroutine(Countdown());    
    }

    private void Continuing()
    {
        StopAllCoroutines();
        GameManager.instance.RestartGame();
    }

    private IEnumerator Countdown()
    {
        // Get countdown text
        countdownTextObj.text = countDownMax.ToString();

        for (countdownValue = countDownMax - 1; countdownValue >= 0; countdownValue--)
        {
            yield return new WaitForSecondsRealtime(1);
            countdownTextObj.text = Math.Max(countdownValue, 0).ToString();
        }

        Time.timeScale = 1;
        GameManager.instance.GameOver();
    }
}
