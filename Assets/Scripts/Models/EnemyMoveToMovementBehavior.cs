using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToMovementBehavior
{
    public Vector3 destination;
    public float speed;

    public EnemyMoveToMovementBehavior(Vector3 destination, float time, Vector3 currentPosition)
    {
        this.destination = destination;
        this.speed = Vector3.Distance(destination, currentPosition) / time;
    }
}
