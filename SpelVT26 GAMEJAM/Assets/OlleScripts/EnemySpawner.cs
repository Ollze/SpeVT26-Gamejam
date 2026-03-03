using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    //public Vector3 spawnPoint;
    public float spawnRate = 2f;
    public int killCount;
    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        

        if (spawnTimer >= spawnRate)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }
    private void SpawnEnemy()
    {
        //roterar till nåt random
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
        //set spawn point till 10 ifrån spelaren och spawna
        Vector3 spawnPoint = enemySpawnPoint.position;
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        //print("enemy spawned at bearing " + randomAngle);      
    }


}
