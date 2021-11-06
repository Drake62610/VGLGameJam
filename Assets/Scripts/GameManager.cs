using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<EnemySpawnData> EnemiesSpawnData = new List<EnemySpawnData>();

    public GameObject enemyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesSpawnData.Add(new EnemySpawnData(new Vector3(2, 2, 0), 3.0f, enemyGameObject));
        EnemiesSpawnData.Add(new EnemySpawnData(new Vector3(4, 3, 0), 4.0f, enemyGameObject));
        EnemiesSpawnData.Add(new EnemySpawnData(new Vector3(3, 5, 0), 2.0f, enemyGameObject));
    }

    // Update is called once per frame
    void Update()
    {
        var enemiesSpawnDataToSpawn = EnemiesSpawnData.FindAll((enemySpawnData) => enemySpawnData.spawnTime <= Time.timeSinceLevelLoad);
        if (enemiesSpawnDataToSpawn.Count > 0)
        {
            foreach (var enemySpawnDataToSpawn in enemiesSpawnDataToSpawn)
            {
                Instantiate(enemySpawnDataToSpawn.enemyGameObject, enemySpawnDataToSpawn.spawnPosition, Quaternion.identity);
            }
            Debug.Log("o/");
            EnemiesSpawnData.RemoveAll(x => enemiesSpawnDataToSpawn.Contains(x));
        }
    }
}
