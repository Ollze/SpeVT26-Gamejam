using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //VARNIG!!!!! DEN HÄR KODEN ANVÄNDS INTE LÄNGRE


    [SerializeField] float health, maxHealth = 50f;
    public float damageAmount = 1;
    

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage()
    {
        damageAmount = ShopUppgrades.upgradedDamageAmount;
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
        TakeDamage();
    }
}
