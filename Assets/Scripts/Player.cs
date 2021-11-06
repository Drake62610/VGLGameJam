using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Image lifeBar;
    public float maxHealth = 3f;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        lifeBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "enemyBullet") {
            lifeBar.fillAmount -= 1f/maxHealth;
            health--;
            if (health <= 0) {
                // Destruction Sequence
                GameManager.instance.triggerContinue();
            }
            Destroy(other.gameObject);
        }
    }
}
