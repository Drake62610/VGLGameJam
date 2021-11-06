using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePatternFront : MonoBehaviour
{
    public float fireRate;
    public GameObject bulletGameObject;
    public Transform bulletSpawnPoint;

    private GameObject gameField;
    private float cooldownTime = 0;

    private void Awake()
    {
        gameField = GameObject.Find("GameField");
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
