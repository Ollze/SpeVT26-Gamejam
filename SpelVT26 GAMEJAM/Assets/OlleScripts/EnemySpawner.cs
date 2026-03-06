using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    //public Vector3 spawnPoint;
    public float spawnRate = 3f;
    public int killCount;
    private float spawnTimer;
    public Animator enemyAnimator;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        
        //dehär är progression systemet som gör allt svårare over time, ganska scuffed men it does the job;
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0f;
            if (killCount < 30) { SpawnEnemy(1); }
            
            
            if(killCount > 10)
            {
                SpawnEnemy(2);
                if (killCount > 20)
                {
                    spawnRate = 2f;
                    if(killCount > 30)
                    {
                        SpawnEnemy(2);
                        
                        if(killCount > 50)
                        {
                            spawnRate = 1.5f;
                            if(killCount > 200 && spawnRate >= 0.5f)
                            {
                                
                                spawnRate -= 0.1f;
                            }
                        }
                    }
                }
            }
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
        EnemyMovement enemyScript = spawnedEnemy.GetComponent<EnemyMovement>();
        //Och väljer vilken sorts enemy det ska va
        if(enemyIndex == 1) { enemyScript.enemy1 = true; };
        if(enemyIndex == 2) { enemyScript.enemy2 = true; };
        if (enemyIndex == 3) { enemyScript.enemy3 = true; };

        if (enemyScript.enemy1 == true)
        {
            enemyAnimator.Play("Enemy1"); 
        }

        if (enemyScript.enemy2 == true)
        {
            enemyAnimator.Play("Enemy2");
        }

        if (enemyScript.enemy3 == true)
        {
            enemyAnimator.Play("Enemy3side");
        }
        
    }


}
