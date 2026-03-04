using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int damage = 2;
    public float attackCooldown = 1.5f;
    private float attackTimer;
    private bool isTouchingPlayer = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouchingPlayer)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                playerHealth.TakeDamage(damage);
                attackTimer = attackCooldown;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouchingPlayer = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouchingPlayer = false;
        }
    }
}