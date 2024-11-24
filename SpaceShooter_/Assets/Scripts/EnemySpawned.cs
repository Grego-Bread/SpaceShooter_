using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawned : MonoBehaviour
{


    public GameObject Enemy;

    public float spawnRate = 2f;

    public float minXAxisSpawnValue = -8f;
    public float maxXAxisSpawnValue = 8f;

    public float yAsixSpawnValue = 4f;

    private float timeSinceLastAction = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastAction += Time.deltaTime;

        if (timeSinceLastAction >= spawnRate)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float xPosition = Random.Range(minXAxisSpawnValue, maxXAxisSpawnValue);
        Vector2 spawnPosition  = new Vector2(xPosition, yAsixSpawnValue);
        Instantiate(Enemy, spawnPosition, Quaternion.identity);

        timeSinceLastAction = 0f;
    }
}
