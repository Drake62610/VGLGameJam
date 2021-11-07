using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScrollLeftToRight : MonoBehaviour
{
    private EnemyMoveToMovementBehavior moveTo;
    private EnemyDamaged ennemy;

    // Start is called before the first frame update
    void Start()
    {
        ennemy = GetComponent<EnemyDamaged>();
        moveTo = new EnemyMoveToMovementBehavior(new Vector3(6f, transform.localPosition.y, 0) + transform.parent.position, 3f, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemy.health >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo.destination, moveTo.speed * Time.deltaTime);
            if (transform.position == moveTo.destination)
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
