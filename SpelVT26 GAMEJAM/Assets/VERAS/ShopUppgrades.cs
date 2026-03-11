using System.Collections;
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
    public bool playerInside = false;
    public bool shopOpen;
    public MenuMusic menuAudio;
    public TextMeshProUGUI dmgStat;
    public TextMeshProUGUI spdStat;
    public TextMeshProUGUI hpStat;
    public TextMeshProUGUI manaStat;
    public TextMeshProUGUI coinStat;
    private float dmgUpgradeCost = 10f;
    private float spdUpgradeCost = 10f;
    private float hpUpgradeCost = 10f;
    private float manaUpgradeCost = 10f;
    private float coinUpgradeCost = 10f;
    private float wpUpgradeCost = 20f;
    public TextMeshProUGUI dmgCostText;
    public TextMeshProUGUI SPDCostText;
    public TextMeshProUGUI MANACostText;
    public TextMeshProUGUI HPcostText;
    public TextMeshProUGUI WPNcostText;
    public TextMeshProUGUI CoinCostText;
    public Animator textAnimator;
    private bool upgradedWPN = false;
    private bool maxWPN = false;
    public TextMeshProUGUI stockText;
    public TextMeshProUGUI killCount;
    public EnemySpawner enemySpawn;


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
        UpdateUI();
        stockText.gameObject.SetActive(false);

       
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
            menuAudio.PlaylobbyAudio();
            stockText.gameObject.SetActive(false);


        }
        else if (Keyboard.current.eKey.wasPressedThisFrame && !shopOpen && playerInside)
        {
            uiPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
            shopOpen = true;
            print("shopOpen = " + shopOpen);
            menuAudio.PlayMenuOpenSound();
            menuAudio.StoplobbyAudio();
            stockText.gameObject.SetActive(false);
            if (maxWPN == true)
            {
                stockText.gameObject.SetActive(true);
            }

        }
        dmgStat.text = ("DMG per bullet: " + upgradedDamageAmount.ToString());
        spdStat.text = ("MoveSpeed: " + playerCode.moveSpeed.ToString());
        hpStat.text = ("HP: " + playerHealth.health.ToString());
        manaStat.text = ("Max mana: " + playerCode.MaxMana.ToString());
        coinStat.text = ("coin gain: " + playerCode.coinGain.ToString());
        UpdateUI();
    }


    public void DMGuppgrade()
    {
        if (playerCode.Currency >= dmgUpgradeCost)
        {
            playerCode.Currency += -dmgUpgradeCost;
            upgradedDamageAmount += 0.5f;
            print("button pressed");
            
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            dmgUpgradeCost += 10f;
            dmgUpgradeCost *= 1.2f;
            dmgCostText.text = dmgUpgradeCost.ToString();
            
        }
        else
        {
            print("Animated");
            textAnimator.SetTrigger("Poor");
        }
        
    }

    public void SPDuppgrade()
    {
        
        if (playerCode.Currency >= spdUpgradeCost)
        {
            playerCode.moveSpeed += 1f;
            print("button pressed");
            playerCode.Currency += -spdUpgradeCost;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            spdUpgradeCost += 5f;
            spdUpgradeCost *= 1.3f;
            SPDCostText.text = spdUpgradeCost.ToString();
        }
        else
        {
            textAnimator.SetTrigger("Poor");
        }

    }

    public void ManaUppgrade()
    {
        
        if (playerCode.Currency >= manaUpgradeCost)
        {
            playerCode.MaxMana += 100f;
            playerCode.Currency += -manaUpgradeCost;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            playerCode.manaRegen += 20f;
            playerCode.Mana.maxValue = playerCode.MaxMana;
            playerCode.Mana.value = playerCode.CurrentMana;
            manaUpgradeCost += 5f;
            manaUpgradeCost *= 1.5f;
            MANACostText.text = manaUpgradeCost.ToString();
            UpdateUI();
        }
        else
        {
            textAnimator.SetTrigger("Poor");
        }


    }

    public void CoinUppgrade()
    {
       
        if (playerCode.Currency >= coinUpgradeCost)
        {
            playerCode.Currency -= coinUpgradeCost;
            playerCode.coinGain += 0.5f;
            
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            coinUpgradeCost += 8;
            coinUpgradeCost *= 1.5f;
            CoinCostText.text = coinUpgradeCost.ToString();
            UpdateUI();
        }
        else
        {
            textAnimator.SetTrigger("Poor");
        }

    }

    public void HealthUppgrade()
    {
        if (playerCode.Currency >= hpUpgradeCost)
        {
            playerCode.Currency += -hpUpgradeCost;
            playerHealth.health += 1;
            playerHealth.maxHealth += 1;
            
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            playerHealth.healthBar.maxValue = playerHealth.maxHealth;
            playerHealth.healthBar.value = playerHealth.health;
            hpUpgradeCost += 8f;
            hpUpgradeCost *= 1.3f;
            HPcostText.text = hpUpgradeCost.ToString();
            UpdateUI();
        }
        else
        {
            textAnimator.SetTrigger("Poor");
        }


    }

    public void WeaponUppgrades()
    {

        if (playerCode.Currency >= wpUpgradeCost && upgradedWPN == false && maxWPN == false)
        {
            playerCode.Currency += -wpUpgradeCost;
            var shape = particles.shape;
            shape.radius = 1f;
            shape.angle = 40f;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            var emission = particles.emission; emission.rateOverTime = 175f;
            
            wpUpgradeCost += 15f;
            wpUpgradeCost *= 1.8f;
            WPNcostText.text = wpUpgradeCost.ToString();
            UpdateUI();
            upgradedWPN = true;
        }
        if (playerCode.Currency >= wpUpgradeCost && upgradedWPN == true && maxWPN == false)
        {
            playerCode.Currency += -wpUpgradeCost;
            var shape = particles.shape;
            shape.radius = 2f;
            shape.angle = 50f;
            playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
            var emission = particles.emission; emission.rateOverTime = 200f;
            UpdateUI();
            maxWPN = true;
        }
        if (maxWPN == true)
        {
            stockText.gameObject.SetActive(true);
            WPNcostText.gameObject.SetActive(false);
        }

        else
        {
            textAnimator.SetTrigger("Poor");
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


    public void UpdateUI()
    {
        dmgStat.text = ("DMG per bullet: " + upgradedDamageAmount.ToString());
        spdStat.text = ("MoveSpeed: " + playerCode.moveSpeed.ToString());
        hpStat.text = ("HP: " + playerHealth.health.ToString());
        manaStat.text = ("Max mana: " + playerCode.MaxMana.ToString());
        coinStat.text = ("coin gain: " + playerCode.coinGain.ToString());
        playerCode.coinText.text = ("Stardust: " + playerCode.Currency.ToString());
        CoinCostText.text = (coinUpgradeCost.ToString());
        SPDCostText.text = (spdUpgradeCost.ToString());
        MANACostText.text = (manaUpgradeCost.ToString());
        HPcostText.text = (hpUpgradeCost.ToString());
        WPNcostText.text = (wpUpgradeCost.ToString());
        dmgCostText.text = (dmgUpgradeCost.ToString());
        killCount.text = ("Kills : " + enemySpawn.killCount.ToString());

}


    
}
