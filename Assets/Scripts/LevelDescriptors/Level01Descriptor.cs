using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Descriptor : MonoBehaviour
{
    [SerializeField]
    public List<EnemySpawnData> enemiesSpawnData = new List<EnemySpawnData>();

    public GameObject gameField;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var enemySpawnData in enemiesSpawnData)
        {
            StartCoroutine(SpawnEnemy(enemySpawnData));
        }
    }

    public IEnumerator SpawnEnemy(EnemySpawnData enemySpawnData)
    {
        yield return new WaitForSeconds(enemySpawnData.spawnTime);
        var enemyGameObject = Instantiate(enemySpawnData.enemyGameObject, enemySpawnData.spawnPosition + gameField.transform.position, Quaternion.identity);
        enemyGameObject.transform.parent = gameField.transform;
    }
}
