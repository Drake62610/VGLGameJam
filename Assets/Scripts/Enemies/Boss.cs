using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct BossPhaseDescriptor
{
    public Sprite sprite;
    public int maxHealth;

    public BossPhaseDescriptor(Sprite sprite, int maxHealth)
    {
        this.sprite = sprite;
        this.maxHealth = maxHealth;
    }
}


public class Boss : EnemyDamaged
{
    public List<BossPhaseDescriptor> phaseDescriptors = new List<BossPhaseDescriptor>();
    public int nbStocks = 3;
    public bool IsActivated { get; private set; }

    private BossLifeBar bossLifeBar;
    private SpriteRenderer spriteRenderer;
    private int maxNbStocks;

    // Start is called before the first frame update
    void Start()
    {
        maxNbStocks = nbStocks;
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
                    break;
                }
            }
        }
    }

    public new void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsActivated)
            return;

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

        int idx = maxNbStocks - nbStocks - 1;

        SetMaxHealth(phaseDescriptors[idx].maxHealth);
        spriteRenderer.sprite = phaseDescriptors[idx].sprite;
        bossLifeBar.SetFillAmount(1);
        bossLifeBar.SetLifeBarIndex(nbStocks);
    }

    // Enable lifebar + enable firing
    public void Activate()
    {
        bossLifeBar.gameObject.SetActive(true);
        IsActivated = true;
    }
}
