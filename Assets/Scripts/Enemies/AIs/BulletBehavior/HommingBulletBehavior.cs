using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HommingBulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float ttl = 5f;
    private GameObject[] players; 
    private Vector3 playerPosition;
    private Vector3 playerDirection;
    void Start() {
        players = GameObject.FindGameObjectsWithTag("player");
        if (players == null) {
            playerPosition = new Vector3(0,1,0);
        }
        playerPosition = players[0].transform.position;
        playerDirection = (playerPosition - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += playerDirection.normalized * speed * Time.deltaTime;
        Destroy(this.gameObject, ttl);
    }
}

