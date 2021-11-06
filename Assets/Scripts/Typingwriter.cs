using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typingwriter : MonoBehaviour
{
    string originaleTexte;
    Text uiText;
    public float delay = 0.05f;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        uiText = GetComponent<Text>();
        originaleTexte = uiText.text;
        uiText.text = null;
        StartCoroutine(ShowLetterByLetter());
    }

    IEnumerator ShowLetterByLetter()
    {
        for (int i=0; i <= originaleTexte.Length; i++) 
        {
            uiText.text = originaleTexte.Substring(0, i);
            if (i < originaleTexte.Length)
            {
                if(originaleTexte.Substring(i,1) != " ")
                {
                    audioSource.Play();
                }
            }
            
            yield return new WaitForSeconds(delay);
        }
    }
}
