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
   public float timeToDelay;
    
    // Start is called before the first frame update
    public void PrepareToStart()
    {
       StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        GameField.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(timeToDelay);
        audioSource.Play();
        level01Descriptor.LevelStart();
    }



}
