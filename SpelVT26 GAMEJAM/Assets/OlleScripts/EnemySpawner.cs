using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    //public Vector3 spawnPoint;
    private float spawnRate = 3f;
    public int killCount;
    private float spawnTimer;
    private int enemyCount;
    private int maxEnemies = 10;

    private float timeAlive;
    public TextMeshProUGUI statsText;

    private void Update()
    {
        timeAlive += Time.deltaTime;
        int secondsAlive = (int)timeAlive;
        statsText.text = "Time Survived: " + secondsAlive.ToString() + " Seconds " + " | Kills: " + killCount.ToString();
        spawnTimer += Time.deltaTime;
        
        //dehär är progression systemet som gör allt svårare over time, ganska scuffed men it does the job; // olle
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0f;            
            if(enemyCount < maxEnemies)
            {
                if (killCount < 50) { SpawnEnemy(1); }
                if (killCount > 15)
                {
                    
                    SpawnEnemy(2);
                    if (killCount > 20)
                    {
                        maxEnemies = 15;
                        spawnRate = 2.5f;
                        if (killCount > 30)
                        {
                            SpawnEnemy(2);
                            if (killCount > 50) { spawnRate = 2; }

                            if (killCount > 70)
                            {
                                maxEnemies = 25;
                                if (killCount > 100) { SpawnEnemy(3); maxEnemies = 35; }
                                spawnRate = 1.5f;
                                if (killCount > 200)
                                {
                                    spawnRate = 1.3f;
                                }//och här gör vi de omöjligt attt spela om man får massa kills
                                if (killCount > 300) { SpawnEnemy(3); maxEnemies = 50; spawnRate = 1f; }
                                if (killCount > 400) { SpawnEnemy(3); SpawnEnemy(2); maxEnemies = 100;  spawnRate = 0.5f; }
                                if (killCount > 500) { SpawnEnemy(3); SpawnEnemy(3); maxEnemies = 200;  spawnRate = 0.3f; }
                                if (killCount > 800) { SpawnEnemy(3); SpawnEnemy(3); maxEnemies = 200;  spawnRate = 0.1f; }
                            }
                        }
                    }
                }
            }
            EnemyMovement[] array = GameObject.FindObjectsByType<EnemyMovement>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            enemyCount = array.Length;
            print("Enemies On the Map = " + array.Length + "| Current Spawnrate = " + spawnRate);
        }
        
        
    }
    private void SpawnEnemy(int enemyIndex)
    {
        //roterar till nåt random
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
        //set spawn point till 10 ifrån spelaren och spawna
         
        Vector3 spawnPoint = enemySpawnPoint.position;
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        //print("enemy spawned at bearing " + randomAngle);
        // vi kollar scripten på den spawnade enemien
        Animator enemyAnimator = spawnedEnemy.GetComponent<Animator>(); ;
        EnemyMovement enemyScript = spawnedEnemy.GetComponent<EnemyMovement>();
        //Och väljer vilken sorts enemy det ska va
        if(enemyIndex == 1)
        { 
            enemyScript.enemy1 = true;
            
        };
        if(enemyIndex == 2)
        {
            enemyScript.enemy2 = true;
            
        };
        if (enemyIndex == 3)
        {
            enemyScript.enemy3 = true;
            
        };

        
    }


}
