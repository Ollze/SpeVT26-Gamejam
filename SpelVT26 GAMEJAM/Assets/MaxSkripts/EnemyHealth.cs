using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 5f;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; //5-->4....--> 0 = Enemy DIES!

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
