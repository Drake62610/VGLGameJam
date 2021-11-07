using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemyAIScrollGeneralizedPause : MonoBehaviour
{
    private List<EnemyMoveToMovementBehavior> moveTo = new List<EnemyMoveToMovementBehavior>();

    private float modifier = 1;
    private EnemyDamaged ennemy;

    // Start is called before the first frame update
    void Start()
    {

        ennemy = GetComponent<EnemyDamaged>();

        if (transform.localPosition.x < 0)
        {
            modifier = -modifier;
        }
        // (6, y) is considered default side spawn, 
        moveTo.Add(new EnemyMoveToMovementBehavior(new Vector3(transform.localPosition.x - 6f * modifier, transform.localPosition.y, 0) + transform.parent.position, 3f, transform.position));
        moveTo.Add(new EnemyMoveToMovementBehavior(new Vector3(transform.localPosition.x - 6.1f * modifier, transform.localPosition.y, 0) + transform.parent.position, 5f, new Vector3(transform.localPosition.x - 6f * modifier, transform.localPosition.y, 0) + transform.parent.position));
        moveTo.Add(new EnemyMoveToMovementBehavior(new Vector3(transform.localPosition.x - 6.1f * modifier, 12f, 0) + transform.parent.position, 3f, new Vector3(transform.localPosition.x - 6.1f * modifier, transform.localPosition.y, 0) + transform.parent.position));
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemy.health >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo[0].destination, moveTo[0].speed * Time.deltaTime);
            if (transform.position == moveTo[0].destination)
            {
                moveTo.RemoveAt(0);
            }

            if (moveTo.Count <= 0)
            {
                SelfDestruct();
            }
        }
    }

    // Self-destruct should not give any points to the player
    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
