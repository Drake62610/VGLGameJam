using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IParametrableBullet : MonoBehaviour
{
    public float speed = 5f;
    public float ttl = 5f;
    public Vector3 direction = new Vector3(0, -1, 0);

    public string mode = "normal";

    private void OnTriggerEnter2D(Collider2D other) {
        if ( mode == "bounce" && other.tag == "wall") {

            Vector3 normal = new Vector3(0, 0, 0);
            if (other.gameObject.name =="LBoundary") {
                normal = new Vector3(1,0,0);
            }
            else if (other.gameObject.name =="RBoundary") {
                normal = new Vector3(-1,0,0);
            }
            else if (other.gameObject.name =="DBoundary") {
                normal = new Vector3(0,1,0);
            }
            else if (other.gameObject.name =="UBoundary") {
                normal = new Vector3(0,-1,0);
            }
            direction = Vector3.Reflect(direction.normalized, normal);
        }

        if ( mode == "bounceUp" && other.tag == "wall") {
            Debug.Log(other.gameObject.name);
            direction = new Vector3(0,1, 0);
        }
    }
}
