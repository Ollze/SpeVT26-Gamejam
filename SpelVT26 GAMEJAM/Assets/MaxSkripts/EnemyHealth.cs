using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 50f;
    

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; //5-->4....--> 0 = Enemy DIES!
        //print("Current Health " + health);

        if (health <= 0)
        {
            EnemyDied();
        }
    }
    public void EnemyDied()
    {


        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(1f);
    }
}
