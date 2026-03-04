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
        dmgStat.text = ("DMG per bullet: " + upgradedDamageAmount.ToString());
        spdStat.text = ("MoveSpeed: " + playerCode.moveSpeed.ToString());
        hpStat.text = ("HP: " + playerHealth.health.ToString());
        manaStat.text = ("Max mana: " + playerCode.MaxMana.ToString());
        coinStat.text = ("coin gain: " + playerCode.coinGain.ToString());
    }


    public void DMGuppgrade()
    {
        if (playerCode.Currency >= 30f)
        {
            upgradedDamageAmount += 1f;
            print("button pressed");
            playerCode.Currency += -30f;
        }
        if (playerCode.Currency < 30f)
        {
            GetComponent<Animator>().SetTrigger("Poor");
        }
        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            print("collided");
            playerInside = true;
            eText.gameObject.SetActive(true);
        }
      
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (Keyboard.current.eKey.wasPressedThisFrame && !shopOpen)
            {
                uiPanel.gameObject.SetActive(true);
                Time.timeScale = 0f;
                shopOpen = true;
                print("shopOpen = " + shopOpen);
                menuAudio.PlayMenuOpenSound();
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInside = false;
            eText.gameObject.SetActive(false);
            //uiPanel.gameObject.SetActive(false);
            
        }
    }

}
