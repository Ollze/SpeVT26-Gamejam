using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public UnityEngine.UI.Slider healthBar;
    public GameManager gameManager;

    private bool isDead;
    private float healTimer = 0;
    private bool healTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }
    private void Update()
    {
        if (healTimer > 10f && healTime)
        {
            health += 1;
            healthBar.value = health;
            healTime = false;
            healTimer = 0f;

        }
        else if (healTime) { healTimer += Time.deltaTime; }
        if(health > maxHealth && healTime) { healTime = false; }
    }

    public void TakeDamage(int amount)
    {
        healTime = true;
        health -= amount;
        healthBar.value = health;
        
        if (health < 1 && !isDead)
        {
            print("You just died");
            isDead = true;
            Time.timeScale *= 0;
            gameManager.gameOver();
        }


    }
}
