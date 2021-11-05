using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
