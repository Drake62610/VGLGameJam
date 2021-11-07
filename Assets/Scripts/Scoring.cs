using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.instance.playerScore.ToString("00000000");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.instance.playerScore.ToString("00000000");
    }
}
