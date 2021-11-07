using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1BossFirePattern : MonoBehaviour
{
    public float fireRate;
    public GameObject bulletGameObject;
    public Transform middleBulletSpawnPoint;
    public Transform leftBulletSpawnPoint;
    public Transform rightBulletSpawnPoint;
    public int phase = 0;

    private float cooldownTime = 0;

    // Update is called once per frame
    void Update()
    {
        cooldownTime -= Time.deltaTime;
        if (phase == 0)
        {
            if (cooldownTime < 0)
            {
                StartCoroutine(FireFive(middleBulletSpawnPoint.position));
                StartCoroutine(FireFive(leftBulletSpawnPoint.position));
                StartCoroutine(FireFive(rightBulletSpawnPoint.position));
                cooldownTime = fireRate;
            }
        }
    }

    IEnumerator FireFive(Vector3 bulletSpawnPosition)
    {
        for (int i = 0; i < 5; ++i)
        {
            Instantiate(bulletGameObject, bulletSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Fire()
    {
        if (phase == 0)
        {
            Instantiate(bulletGameObject, leftBulletSpawnPoint.position, Quaternion.identity);
            Instantiate(bulletGameObject, rightBulletSpawnPoint.position, Quaternion.identity);
        }
    }
}
