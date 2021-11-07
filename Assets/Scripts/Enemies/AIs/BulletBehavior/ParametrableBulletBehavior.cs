using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrableBulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float ttl = 5f;
    public Vector3 direction = new Vector3(0, -1, 0);

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
        Destroy(this.gameObject, ttl);
    }
}

