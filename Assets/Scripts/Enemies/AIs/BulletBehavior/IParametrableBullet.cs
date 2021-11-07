using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IParametrableBullet : MonoBehaviour
{
    public float speed = 5f;
    public float ttl = 5f;
    public Vector3 direction = new Vector3(0, -1, 0);
}
