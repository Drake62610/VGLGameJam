using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrableLaserBulletBehavior : IParametrableBullet
{
    void Start() {
        transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(direction, new Vector3(0,1,0)));
    }

    // Update is called once per frame
    void Update()
    {  
        transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(direction, new Vector3(0,1,0)));
        transform.position += direction.normalized * speed * Time.deltaTime;
        Destroy(this.gameObject, ttl);
    }
}

