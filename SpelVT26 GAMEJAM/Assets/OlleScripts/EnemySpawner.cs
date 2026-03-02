using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    //public Vector3 spawnPoint;
    public float spawnRate = 2f;
    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }
    void Update()
    {
        
    }
    private void SpawnEnemy()
    {
        //roterar till nåt random
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
        Vector3 spawnPoint = enemySpawnPoint.position;
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        print("enemy spawned at bearing " + randomAngle);
        
    }


}
