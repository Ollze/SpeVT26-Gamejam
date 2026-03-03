using UnityEngine;

public class EnemyMovement : MonoBehaviour
{ 
    //den här coden var orginellt 2 olika koder men jag smasha ihop de med AI så det är enklare att jobba på andra svårare fiender
    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 50f;
    private float health;

    private Rigidbody2D rb;
    private PlayerAwarement playerAwarenessController;
    private Vector2 targetDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarement>();
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    // ================= MOVEMENT =================

    private void UpdateTargetDirection()
    {
        if (playerAwarenessController.AwareOfPlayer)
        {
            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = transform.up * speed;
        }
    }

    // ================= HEALTH =================

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0f)
        {
            EnemyDied();
        }
    }

    private void EnemyDied()
    {
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(1f);
    }
}