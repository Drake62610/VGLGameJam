using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrableLaserBulletBehavior : IParametrableBullet
{

    public float initialPosition;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(direction, new Vector3(0, 1, 0)));
        initialPosition = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (initialPosition - transform.localPosition.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(direction, new Vector3(0, 1, 0)));
        }
        else if (initialPosition - transform.localPosition.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(direction, new Vector3(0, -1, 0)));
        }

        transform.position += direction.normalized * speed * Time.deltaTime;
        Destroy(this.gameObject, ttl);
    }
}

