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

    public EnemySpawnData(Vector2 spawnPosition, float spawnTime, GameObject enemyGameObject)
    {
        this.spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);
        this.spawnTime = spawnTime;
        this.enemyGameObject = enemyGameObject;
    }
}
