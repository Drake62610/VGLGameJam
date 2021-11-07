using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BossFirePattern : MonoBehaviour
{
    public GameObject slowBigBulletGameObject;
    public GameObject simpleParametrableBulletGameObject;
    public GameObject laserBulletGameObject;
    public GameObject bouncingBulletGameObject;

    public Transform middleBulletSpawnPoint;
    public Transform leftBulletSpawnPoint;
    public Transform rightBulletSpawnPoint;

    private float cooldownTime = 0;
    private float secondCooldownTime = 0;
    private int firingCannonIdx;
    private Boss bossData;

    private void Awake()
    {
        bossData = GetComponent<Boss>();
        firingCannonIdx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossData.IsActivated)
            return;

        cooldownTime -= Time.deltaTime;
        secondCooldownTime -= Time.deltaTime;
        if (bossData.nbStocks == 3)
        {
            if (cooldownTime < 0)
            {
                var bullet = Instantiate(laserBulletGameObject, middleBulletSpawnPoint.position, Quaternion.identity);
                bullet.GetComponent<SpriteRenderer>().color = Color.red;
                bullet.GetComponent<IParametrableBullet>().speed *= 1.5f;
                cooldownTime = 0.75f;
            }
            if (secondCooldownTime < 0)
            {
                Transform transformCannonToFire;
                if (firingCannonIdx == 0)
                {
                    transformCannonToFire = leftBulletSpawnPoint;
                    firingCannonIdx = 1;
                }
                else
                {
                    transformCannonToFire = rightBulletSpawnPoint;
                    firingCannonIdx = 0;
                }
                StartCoroutine(FireBigCone(transformCannonToFire.position, simpleParametrableBulletGameObject, 70, 0.15f, Color.cyan));
                secondCooldownTime = 2.25f;
            }
        }
        else if (bossData.nbStocks == 2)
        {
            if (cooldownTime < 0)
            {
                Instantiate(laserBulletGameObject, middleBulletSpawnPoint.position, Quaternion.identity);
                Instantiate(laserBulletGameObject, middleBulletSpawnPoint.position, Quaternion.identity);
                Instantiate(laserBulletGameObject, middleBulletSpawnPoint.position, Quaternion.identity);
                cooldownTime = 1.5f;
            }
        }
    }

    IEnumerator FireBigCone(Vector3 bulletSpawnPosition, GameObject bulletGameObject, int nbBulletsToSpawn, float randomRange, Color color)
    {
        for (int i = 0; i < nbBulletsToSpawn; ++i)
        {
            var bullet = Instantiate(bulletGameObject, bulletSpawnPosition, Quaternion.identity);
            bullet.GetComponent<IParametrableBullet>().direction = new Vector3(
                Random.Range(-randomRange, randomRange),
                -Random.Range(0.2f, 1f), 0
            ).normalized;
            bullet.GetComponent<IParametrableBullet>().speed *= 0.5f;
            bullet.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.0001f);
        }
        yield return null;
    }
}
