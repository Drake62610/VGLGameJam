using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct EnemySpawnData
{
    public Vector3 spawnPosition;
    public float spawnTime;
    public GameObject enemyGameObject;
    public String enemyMovementBehaviorScriptName;

    public EnemySpawnData(Vector2 spawnPosition, float spawnTime, GameObject enemyGameObject, String enemyMovementBehaviorScriptName)
    {
        this.spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);
        this.spawnTime = spawnTime;
        this.enemyGameObject = enemyGameObject;
        this.enemyMovementBehaviorScriptName = enemyMovementBehaviorScriptName;
    }
}
