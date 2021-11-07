using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeBar : MonoBehaviour
{
    public Sprite lifeBarSecondPhaseSprite;
    public Sprite lifeBarThirdPhaseSprite;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetLifeBarIndex(int remainingStocks)
    {
        if (remainingStocks == 2)
        {
            image.sprite = lifeBarSecondPhaseSprite;
        }
        else if (remainingStocks == 1)
        {
            image.sprite = lifeBarThirdPhaseSprite;
        }
    }

    public void SetFillAmount(float amount)
    {
        image.fillAmount = amount;
    }
}
