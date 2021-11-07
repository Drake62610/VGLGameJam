using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int maxHealth;
    public int scoreValue;
    public AudioClip deathClip;
    public int health;

    private void Awake()
    {
        health = maxHealth;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "playerBullet")
        {
            health -= other.GetComponent<PlayerBulletBehavior>().damage;
            if (health <= 0)
            {
                DestroyOnKill();
            }
            Destroy(other.gameObject);
        }
    }

    protected void DestroyOnKill()
    {
        // Use "PlayClipAtPoint" to avoid create an AudioSource and to avoid managing the Destroyed state
        AudioSource.PlayClipAtPoint(deathClip, gameObject.transform.position);
        GameManager.instance.playerScore += scoreValue;
        Destroy(this.gameObject);
    }

    protected void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        health = newMaxHealth;
    }
}
