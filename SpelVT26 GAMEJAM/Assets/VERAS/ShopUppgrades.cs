using UnityEngine;

public class ShopUppgrades : MonoBehaviour
{
    public GameObject player;
    public static float upgradedDamageAmount = 1;
    public PlayerMain playerCode;
    bool istesting;
    public PlayerHealth playerHealth;
    public ParticleSystem particles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<EnemyHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void DMGuppgrade()
    {

        upgradedDamageAmount += 1f;
        print("button pressed");
        
    }

    public void SPDuppgrade()
    {
        playerCode.moveSpeed += 2f;
    }

    public void ManaUppgrade()
    {
        playerCode.MaxMana += 100f;
    }

    public void CoinUppgrade()
    {
        playerCode.coinGain += 1f;
    }

    public void HealthUppgrade()
    {
        playerHealth.health += 1;
        playerHealth.maxHealth += 1;
    }

    public void WeaponUppgrades()
    {
        var shape = particles.shape;
        shape.radius = 2f;
        shape.angle = 40f;

        var emission = particles.emission; emission.rateOverTime = 200f;
    }
}
