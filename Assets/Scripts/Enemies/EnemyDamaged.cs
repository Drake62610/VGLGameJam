using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int health;
    public int scoreValue;
    public AudioClip deathClip;

    private void OnTriggerEnter2D(Collider2D other)
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

    private void DestroyOnKill()
    {
        // Use "PlayClipAtPoint" to avoid create an AudioSource and to avoid managing the Destroyed state
        AudioSource.PlayClipAtPoint(deathClip, gameObject.transform.position);
        GameManager.instance.playerScore += scoreValue;
        Destroy(this.gameObject);
    }
}
