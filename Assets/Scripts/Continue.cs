using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    public Text countdownTextObj;
    public int countDownMax = 10;
    private int countdownValue;
    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState == "continue")
        {
            if (cooldown >= 0)
            {
                cooldown -= Time.unscaledDeltaTime;
            }
            if (GameManager.instance.gameState == "continue" && Input.GetAxisRaw("Fire1") == 1)
            {
                Continuing();
            }
            if (GameManager.instance.gameState == "continue" && Input.GetAxisRaw("Bomb") == 1 && cooldown < 0)
            {
                // Avoid overflowing to negative values
                if (countdownValue > 1)
                {
                    countdownValue--;
                }
                countdownTextObj.text = countDownMax.ToString();
                countdownTextObj.text = countdownValue.ToString();
                cooldown = 0.1f;
            }
        }

    }

    public void StartCountdown()
    {
        StartCoroutine(Countdown());    
    }

    private void Continuing()
    {
        StopAllCoroutines();
        GameManager.instance.RestartGame();
    }

    // COROUTINE
    private IEnumerator Countdown()
    {
        // Get countdown text
        countdownTextObj.text = countDownMax.ToString();

        for (countdownValue = countDownMax - 1; countdownValue >= 0; countdownValue--)
        {
            yield return new WaitForSecondsRealtime(1);
            countdownTextObj.text = countdownValue.ToString();
        }

        Time.timeScale = 1;
        GameManager.instance.GameOver();
    }
}
