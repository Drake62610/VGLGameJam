using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToCenterWaitThenLeaveGeneralized : MonoBehaviour
{
    private List<EnemyMoveToMovementBehavior> moveTo = new List<EnemyMoveToMovementBehavior>();
    private int modifiers = 1;

    private IFirePattern firePattern;

    // Start is called before the first frame update
    void Start()
    {

        firePattern = gameObject.GetComponentInParent<IFirePattern>();
        firePattern.cooldownTime = 300;

        // (4.5, 12) is considered default upper spawn, 
        if (transform.localPosition.x < 0) {
            modifiers = -modifiers;
        }
        moveTo.Add(new EnemyMoveToMovementBehavior(new Vector3(transform.localPosition.x - 4.5f * modifiers, transform.localPosition.y - 4, 0) + transform.parent.position, 3f, transform.position));
        moveTo.Add(new EnemyMoveToMovementBehavior(new Vector3(transform.localPosition.x - 4.5f * modifiers, transform.localPosition.y - 5, 0) + transform.parent.position, 5f, 
        new Vector3(transform.localPosition.x - 4.5f * modifiers, transform.localPosition.y - 4, 0) + transform.parent.position));
        moveTo.Add(new EnemyMoveToMovementBehavior(new Vector3(transform.localPosition.x - 4.5f * modifiers, 12, 0) + transform.parent.position, 3f, 
        new Vector3(transform.localPosition.x - 4.5f * modifiers, transform.localPosition.y - 5, 0) + transform.parent.position));
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTo[0].destination, moveTo[0].speed * Time.deltaTime);
        if (transform.position == moveTo[0].destination)
        {
            firePattern.cooldownTime = 0.5f;
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
