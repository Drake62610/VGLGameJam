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
        if (other.tag == "playerBullet" && health>0)
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
        StartCoroutine(EnemyDied());
    }

    protected void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        health = newMaxHealth;
    }

    IEnumerator EnemyDied()
    {
        // Use "PlayClipAtPoint" to avoid create an AudioSource and to avoid managing the Destroyed state
        AudioSource.PlayClipAtPoint(deathClip, gameObject.transform.position, 0.5f);
        gameObject.GetComponent<Animator>().SetTrigger("Die");
        GameManager.instance.playerScore += scoreValue;
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(this.gameObject);
    }
}
