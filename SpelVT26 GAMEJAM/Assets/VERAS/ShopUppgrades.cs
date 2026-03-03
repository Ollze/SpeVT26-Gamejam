using UnityEngine;

public class ShopUppgrades : MonoBehaviour
{
    public GameObject player;
    public static float upgradedDamageAmount = 1;
    public PlayerMain playerCode;

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
        
    }

    public void SPDuppgrade()
    {
        playerCode.moveSpeed += 2f;
    }

    public void ManaUppgrade()
    {
        playerCode.MaxMana += 100f;
    }
}
