using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamaged : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        if(other.tag == "playerBullet") {
            Destroy(this.gameObject);
        }
        
    }
}
