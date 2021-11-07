using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : EnemyDamaged
{
    public Sprite secondPhaseSprite;
    public Sprite thirdPhaseSprite;
    public int nbStocks = 3;

    private BossLifeBar bossLifeBar;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Find BossLifeBar GameObject by name, even if it's disabled
        BossLifeBar[] objs = Resources.FindObjectsOfTypeAll<BossLifeBar>();
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == "BossLifeBar")
                {
                    bossLifeBar = objs[i];
                    bossLifeBar.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    public new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "playerBullet")
        {
            health -= other.GetComponent<PlayerBulletBehavior>().damage;
            bossLifeBar.SetFillAmount((float)base.health / (float)base.maxHealth);
            if (health <= 0)
            {
                RemoveStock();
            }
            Destroy(other.gameObject);
        }
    }

    private void RemoveStock()
    {
        nbStocks -= 1;
        if (nbStocks == 0)
        {
            base.DestroyOnKill();
            return;
        }

        maxHealth = 2000;
        health = 2000;
        bossLifeBar.SetFillAmount(1);
        bossLifeBar.SetLifeBarIndex(nbStocks);
        SetSpriteIndex(nbStocks);
    }

    private void SetSpriteIndex(int remainingStocks)
    {
        if (remainingStocks == 2)
        {
            spriteRenderer.sprite = secondPhaseSprite;
        }
        else if (remainingStocks == 1)
        {
            spriteRenderer.sprite = thirdPhaseSprite;
        }
    }
}
