using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePatternDirection : MonoBehaviour
{

    private GameObject[] players;
    private Vector3 playerPosition;
    private Vector3 playerDirection;

    public string behaviorType;

    public float fireRate;
    // If set to 0 is disabled
    public float shootingDelay;
    public GameObject bulletGameObject;
    public Transform bulletSpawnPoint;

    public float cooldownTime = 0;

    public float speed = 5f;
    public float ttl = 5f;
    public Vector3 direction = new Vector3(0, 1, 0);

    public Color color = new Color(0, 0, 0);

    private void Awake()
    {
        if (shootingDelay != 0)
        {
            cooldownTime = shootingDelay;
        }
    }

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("player");

    }

    // Update is called once per frame
    void Update()
    {


        cooldownTime -= Time.deltaTime;

        if (cooldownTime < 0)
        {
            cooldownTime = fireRate;

            // Player Recognition
            players = GameObject.FindGameObjectsWithTag("player");
            if (players.Length == 0)
            {
                playerPosition = new Vector3(1, 1, 0).normalized;

            }
            else
            {
                playerPosition = players[0].transform.position;
            }
            playerDirection = (playerPosition - transform.position).normalized;

            // Bullet Mode
            if (behaviorType == "random")
            {
                Fire(new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.2f, 1f), 0).normalized);
            }
            else if (behaviorType == "homming")
            {
                Fire(playerDirection);
            }
            else
            {
                Fire(direction);
            }
        }
    }

    private void Fire(Vector3 d)
    {
        GameObject bullet = Instantiate(bulletGameObject, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<IParametrableBullet>().speed = 5f;
        bullet.GetComponent<IParametrableBullet>().ttl = 20f;
        bullet.GetComponent<IParametrableBullet>().direction = d;
        bullet.GetComponent<SpriteRenderer>().color = color;
    }

}
