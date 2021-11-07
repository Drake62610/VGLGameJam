using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgAnimatedScript : MonoBehaviour
{
    public Sprite[] animatedBg;
    public Image animateImageObj;
    public SpriteRenderer animateSpriteObj;

    public string typeOfObj;

    // Update is called once per frame
    void Update()
    {
        if (typeOfObj == "image")
            animateImageObj.sprite = animatedBg[(int)(Time.time * 10) % animatedBg.Length];
        if (typeOfObj == "sprite")
            animateSpriteObj.sprite = animatedBg[(int)(Time.time * 10) % animatedBg.Length];
    }
}
