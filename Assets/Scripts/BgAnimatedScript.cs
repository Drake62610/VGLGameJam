using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgAnimatedScript : MonoBehaviour
{
    public Sprite[] animatedImages;
    public Image animateImageObj;

    // Update is called once per frame
    void Update()
    {
        animateImageObj.sprite = animatedImages [(int)(Time.time*10)%animatedImages.Length];
    }
}
