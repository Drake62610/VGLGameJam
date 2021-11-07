using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCirclePattern : MonoBehaviour
{
    public float fireRate;
    // If set to 0 is disabled
    public ParametrableBulletBehavior bulletGameObject;
    public Transform bulletSpawnPoint;

    public string behaviorType;

    private GameObject[] players; 
    private Vector3 playerPosition;
    private Vector3 playerDirection;

    private GameObject gameField;

    public float numberOfBullets = 10;
    public float radius = 3;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("player");
        if (players == null) {
            playerPosition = new Vector3(0,1,0);
        }
        playerPosition = players[0].transform.position;
        playerDirection = (playerPosition - transform.position).normalized;

        if (behaviorType == "circleSpread") {
            StartCoroutine(FireCircleSpread());
            
        } else {
            StartCoroutine(FireCircle());
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator FireCircle()
    {
        List<ParametrableBulletBehavior> bullets = new List<ParametrableBulletBehavior>();

        for (var i = 0; i < numberOfBullets; i++)
        {
            var x = bulletSpawnPoint.position.x + radius * Mathf.Cos(2 * Mathf.PI * i / numberOfBullets);
            var y = bulletSpawnPoint.position.y + radius * Mathf.Sin(2 * Mathf.PI * i / numberOfBullets);

            ParametrableBulletBehavior bullet = Instantiate(bulletGameObject, new Vector3(x, y, 0), Quaternion.identity);

            bullet.speed = 0f;
            bullet.ttl = 10f;

            bullets.Add(bullet);

            yield return new WaitForSeconds(1/numberOfBullets);
        }

        for (var i = 0; i < numberOfBullets; i++)
        {
            bullets[i].speed = 5f;
            bullets[i].ttl = 20f;
            bullets[i].direction= playerDirection;
        }
    }

    private IEnumerator FireCircleSpread()
    {
        List<ParametrableBulletBehavior> bullets = new List<ParametrableBulletBehavior>();

        for (var i = 0; i < numberOfBullets; i++)
        {
            var x = bulletSpawnPoint.position.x + radius * Mathf.Cos(2 * Mathf.PI * i / numberOfBullets);
            var y = bulletSpawnPoint.position.y + radius * Mathf.Sin(2 * Mathf.PI * i / numberOfBullets);

            ParametrableBulletBehavior bullet = Instantiate(bulletGameObject, new Vector3(x, y, 0), Quaternion.identity);

            bullet.speed = 0f;
            bullet.ttl = 10f;

            bullets.Add(bullet);

            yield return new WaitForSeconds(1/numberOfBullets);
        }

        for (var i = 0; i < numberOfBullets; i++)
        {
            bullets[i].speed = 5f;
            bullets[i].ttl = 20f;
            bullets[i].direction= bullets[i].gameObject.transform.position - bulletSpawnPoint.position;
        }
    }
}
