using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public Text startText;
    public string firstScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            SceneManager.LoadScene(firstScene);
        }
    }

    //Coroutine
    public IEnumerator Blink() {
        while(true) {
            startText.text = "";
            yield return new WaitForSeconds(1f);
            startText.text = "PRESS FIRE BUTTON";
            yield return new WaitForSeconds(1f);
        }
    }
}
