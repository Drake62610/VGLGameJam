using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
   public Animator crossfadeTransition;
   public Animator canvasCamera;
   public Animator CanvasOverlay;
   public Animator GameField;
   public Level01Descriptor level01Descriptor;
   public AudioSource audioSource;
    
    // Start is called before the first frame update
    public void PrepareToStart()
    {
       StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        GameField.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(6f);
        audioSource.Play();
        level01Descriptor.LevelStart();
    }



}
