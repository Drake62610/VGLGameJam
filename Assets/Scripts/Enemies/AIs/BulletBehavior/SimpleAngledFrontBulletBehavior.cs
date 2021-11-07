using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAngledFrontBulletBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float ttl = 5f;

    private Vector3 randomDirection;

    void Start() {
        randomDirection = new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(0.2f,1f), 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  randomDirection * -speed * Time.deltaTime;
        Destroy(this.gameObject, ttl);
    }
}
