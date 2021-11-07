using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1BossFirePattern : MonoBehaviour
{
    public float fireRate;
    public GameObject homingBulletGameObject;
    public GameObject simpleAngledBulletGameObject;
    public GameObject slowSimpleAngledBulletGameObject;

    public Transform middleBulletSpawnPoint;
    public Transform leftBulletSpawnPoint;
    public Transform rightBulletSpawnPoint;

    private float cooldownTime = 0;
    private Boss bossData;

    private void Awake()
    {
        bossData = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossData.IsActivated)
            return;

        cooldownTime -= Time.deltaTime;
        if (bossData.nbStocks == 3)
        {
            if (cooldownTime < 0)
            {
                StartCoroutine(FireFive(middleBulletSpawnPoint.position));
                StartCoroutine(FireFive(leftBulletSpawnPoint.position));
                StartCoroutine(FireFive(rightBulletSpawnPoint.position));
                cooldownTime = fireRate;
            }
        }
        else if (bossData.nbStocks == 2)
        {
            if (cooldownTime < 0)
            {
                StartCoroutine(FireALot(leftBulletSpawnPoint.position, simpleAngledBulletGameObject, 30));
                StartCoroutine(FireALot(rightBulletSpawnPoint.position, simpleAngledBulletGameObject, 30));
                cooldownTime = 2;
            }
        }
        else if (bossData.nbStocks == 1)
        {
            if (cooldownTime < 0)
            {
                StartCoroutine(FireALot(leftBulletSpawnPoint.position, slowSimpleAngledBulletGameObject, 15));
                StartCoroutine(FireALot(rightBulletSpawnPoint.position, slowSimpleAngledBulletGameObject, 15));
                StartCoroutine(FireFive(middleBulletSpawnPoint.position));
                StartCoroutine(FireFive(leftBulletSpawnPoint.position));
                StartCoroutine(FireFive(rightBulletSpawnPoint.position));
                cooldownTime = 1.5f;
            }
        }
    }

    IEnumerator FireFive(Vector3 bulletSpawnPosition)
    {
        for (int i = 0; i < 5; ++i)
        {
            Instantiate(homingBulletGameObject, bulletSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FireALot(Vector3 bulletSpawnPosition, GameObject bulletGameObject, int nbBulletsToSpawn)
    {
        for (int i = 0; i < nbBulletsToSpawn; ++i)
        {
            Instantiate(bulletGameObject, bulletSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.025f);
        }
    }
}
