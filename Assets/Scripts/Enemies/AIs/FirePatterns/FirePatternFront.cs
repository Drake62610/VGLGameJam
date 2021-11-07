using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePatternFront : MonoBehaviour
{
    public float fireRate;
    // If set to 0 is disabled
    public float shootingDelay;
    public GameObject bulletGameObject;
    public Transform bulletSpawnPoint;

    public float cooldownTime = 0;

    private void Awake()
    {
        if (shootingDelay != 0) {
            cooldownTime = shootingDelay;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTime -= Time.deltaTime;

        if (cooldownTime < 0)
        {
            Fire();
            cooldownTime = fireRate;
        }
    }

    private void Fire()
    {
        Instantiate(bulletGameObject, bulletSpawnPoint.position, Quaternion.identity);
    }
}
