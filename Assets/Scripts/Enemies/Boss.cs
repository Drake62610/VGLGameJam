using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : EnemyDamaged
{
    private Image lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        // Find BossLifeBar GameObject by name, even if it's disabled
        Image[] objs = Resources.FindObjectsOfTypeAll<Image>();
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == "BossLifeBar")
                {
                    lifeBar = objs[i];
                    lifeBar.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    public new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.tag == "playerBullet")
        {
            lifeBar.fillAmount = (float)base.health / (float)base.maxHealth;
        }
    }
}
