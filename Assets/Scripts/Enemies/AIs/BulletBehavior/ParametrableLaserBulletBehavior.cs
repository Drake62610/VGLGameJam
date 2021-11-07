using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrableLaserBulletBehavior : IParametrableBullet
{
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
        Destroy(this.gameObject, ttl);
    }
}

