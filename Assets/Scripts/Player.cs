using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image lifeBar;
    public float maxHealth = 3f;
    public AudioSource audioSourceHit;
    private float health;
    private SpriteRenderer sprite;
    private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        lifeBar.fillAmount = 1;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "enemyBullet" && !isInvincible) {
            lifeBar.fillAmount -= 1f / maxHealth;
            audioSourceHit.Play();
            health--;
            if (health <= 0) {
                // Destruction Sequence
                GameManager.instance.triggerContinue();
            }
            else
            {
                MakeInvincible();
            }
            Destroy(other.gameObject);
        }
    }

    private void MakeInvincible()
    {
        isInvincible = true;
        StartCoroutine("BlinkPlayerSprite");
        Invoke("StopInvincible", 1.5f);
    }


    //Coroutine
    private IEnumerator BlinkPlayerSprite()
    {
        const float blinkSpd = 0.05f;
        while (isInvincible)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(blinkSpd);
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(blinkSpd);
        }
        sprite.enabled = true;
    }

    private void StopInvincible()
    {
        isInvincible = false;
    }
}
