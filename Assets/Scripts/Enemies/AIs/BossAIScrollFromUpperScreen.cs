using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAIScrollFromUpperScreen : MonoBehaviour
{
    private EnemyMoveToMovementBehavior moveTo;
    private Boss bossData;
    private GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("player");
        foreach (var player in players)
        {
            player.BroadcastMessage("MakeActive", false);
        }
        bossData = GetComponent<Boss>();
        moveTo = new EnemyMoveToMovementBehavior(new Vector3(transform.localPosition.x, 9f, 0) + transform.parent.position, 3f, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTo.destination, moveTo.speed * Time.deltaTime);
        if (transform.position == moveTo.destination && !bossData.IsActivated)
        {
            bossData.Activate();
            foreach (var player in players)
            {
                player.BroadcastMessage("MakeActive", true);
            }
        }
    }
}
