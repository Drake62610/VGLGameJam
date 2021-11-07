using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToCenterWaitThenLeave : MonoBehaviour
{
    private List<EnemyMoveToMovementBehavior> moveTo = new List<EnemyMoveToMovementBehavior>();

    // Start is called before the first frame update
    void Start()
    {
        moveTo.Add(new EnemyMoveToMovementBehavior(new Vector3(0, 8, 0) + transform.parent.position, 3f, transform.position));
        moveTo.Add(new EnemyMoveToMovementBehavior(new Vector3(0, 12, 0) + transform.parent.position, 3f, transform.position));
    }

    // Update is called once per frame
    void Update()
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

    // Self-destruct should not give any points to the player
    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
