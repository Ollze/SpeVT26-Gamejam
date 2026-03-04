using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopUppgrades : MonoBehaviour
{
    public GameObject player;
    public static float upgradedDamageAmount = 1;
    public PlayerMain playerCode;
    bool istesting;
    public PlayerHealth playerHealth;
    public ParticleSystem particles;
    public GameObject uiPanel;
    public TextMeshProUGUI eText;
    private bool playerInside = false;
    private bool shopOpen;
    public MenuMusic menuAudio;
    public TextMeshProUGUI dmgStat;
    public TextMeshProUGUI spdStat;
    public TextMeshProUGUI hpStat;
    public TextMeshProUGUI manaStat;
    public TextMeshProUGUI coinStat;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<EnemyHealth>();
        uiPanel.gameObject.SetActive(false);
        eText.gameObject.SetActive(false);
        shopOpen = false;
        dmgStat.text = ("DMG per bullet: " + upgradedDamageAmount.ToString());
        spdStat.text = ("MoveSpeed: " + playerCode.moveSpeed.ToString());
        hpStat.text = ("HP: " + playerHealth.health.ToString());
        manaStat.text = ( "Max mana: " + playerCode.MaxMana.ToString());
        coinStat.text = ("coin gain: " + playerCode.coinGain.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && shopOpen)
        {
            Time.timeScale = 1f;
            shopOpen = false;
            uiPanel.gameObject.SetActive(false);
            print("Pressed E to turn OFF shop");
            menuAudio.StopMenuOpenSound();

        }
        if (Keyboard.current.eKey.wasPressedThisFrame && !shopOpen)
        {
            uiPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
            shopOpen = true;
            print("shopOpen = " + shopOpen);
            menuAudio.PlayMenuOpenSound();
        }
        dmgStat.text = ("DMG per bullet: " + upgradedDamageAmount.ToString());
        spdStat.text = ("MoveSpeed: " + playerCode.moveSpeed.ToString());
        hpStat.text = ("HP: " + playerHealth.health.ToString());
        manaStat.text = ("Max mana: " + playerCode.MaxMana.ToString());
        coinStat.text = ("coin gain: " + playerCode.coinGain.ToString());
    }


    public void DMGuppgrade()
    {
        if (playerCode.Currency >= 10f)
        {
            upgradedDamageAmount += 1f;
            print("button pressed");
            playerCode.Currency += -10f;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
        }
        if (playerCode.Currency < 10f)
        {
            
        }
        
    }

    public void SPDuppgrade()
    {
        
        if (playerCode.Currency >= 10f)
        {
            playerCode.moveSpeed += 2f;
            print("button pressed");
            playerCode.Currency += -10f;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
        }
        if (playerCode.Currency < 10f)
        {
           
        }
    }

    public void ManaUppgrade()
    {
        
        if (playerCode.Currency >= 10f)
        {
            playerCode.MaxMana += 100f;
            playerCode.Currency += -10f;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            playerCode.manaRegen += 20f;
            playerCode.Mana.maxValue = playerCode.MaxMana;
            playerCode.Mana.value = playerCode.CurrentMana;
        }
        if (playerCode.Currency < 10f)
        {
            
        }

    }

    public void CoinUppgrade()
    {
       
        if (playerCode.Currency >= 10f)
        {
            playerCode.coinGain += 1f;
            playerCode.Currency += -10f;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
        }
        if (playerCode.Currency < 10f)
        {
            
        }
    }

    public void HealthUppgrade()
    {
        if (playerCode.Currency >= 10f)
        {
            playerHealth.health += 1;
            playerHealth.maxHealth += 1;
            playerCode.Currency += -10f;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            playerHealth.healthBar.maxValue = playerHealth.maxHealth;
            playerHealth.healthBar.value = playerHealth.health;
        }
        if (playerCode.Currency < 10f)
        {
            
        }
       
    }

    public void WeaponUppgrades()
    {

        if (playerCode.Currency >= 20f)
        {
            var shape = particles.shape;
            shape.radius = 2f;
            shape.angle = 40f;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            var emission = particles.emission; emission.rateOverTime = 200f;
            playerCode.Currency += -20f;
        }
        if (playerCode.Currency < 20f)
        {
            
        }
       
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Player entered trigger");
            playerInside = true;
            eText.gameObject.SetActive(true);
        }
    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
            eText.gameObject.SetActive(false);
        }
    }

}
