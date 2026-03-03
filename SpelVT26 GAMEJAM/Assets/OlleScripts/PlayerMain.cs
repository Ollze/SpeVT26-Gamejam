using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5;
    public ParticleSystem shootParticles;
    public float MaxMana = 100f;
    public float CurrentMana;
    public Slider Mana;
    public Slider playerHealth;
    public float Currency = 0;
    bool manaOverheat;
    bool isshooting;
    void Start()
    {
        CurrentMana += MaxMana;
    }

    // Update is called once per frame
    void Update()
    {
        //print("Current Mana " + CurrentMana);
        if (Keyboard.current.wKey.isPressed) { transform.position += new Vector3(0, 1, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.sKey.isPressed) { transform.position += new Vector3(0, -1, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.dKey.isPressed) { transform.position += new Vector3(1, 0, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.aKey.isPressed) { transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime; }
        if (Mouse.current.leftButton.isPressed && CurrentMana > 0f && !manaOverheat)
        {
            Shoot();
            print("Left click pressed");
            if (CurrentMana <= 0f)
            { manaOverheat = true; CurrentMana = 0f; print("Mana overheat"); }
        }
        else
        {
            isshooting = false;
            if (CurrentMana < MaxMana)
            {
                CurrentMana += 20f * Time.deltaTime;

                if (CurrentMana>= MaxMana)
                {
                    manaOverheat = false;
                    print("Manaoverheat" + manaOverheat);
                }
            }
        }
    }


    public void Shoot()
    {
        shootParticles.Play();
        CurrentMana += -15f * Time.deltaTime;
        isshooting = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            Destroy(collision.collider.gameObject);
            Currency += 1f;
            print("Current points/coins " + Currency);
        }
    }
}
