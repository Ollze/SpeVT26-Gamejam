using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float moveSpeed = 5;
    public ParticleSystem shootParticles;
    public float MaxMana = 100f;
    public float CurrentMana;
    public Slider Mana;
    public Slider playerHealth;
    void Start()
    {
        MaxMana = CurrentMana;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed) { transform.position += new Vector3(0, 1, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.sKey.isPressed) { transform.position += new Vector3(0, -1, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.dKey.isPressed) { transform.position += new Vector3(1, 0, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.aKey.isPressed) { transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime; }
        if (Mouse.current.leftButton.isPressed && CurrentMana > 0)
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        shootParticles.Play();
        CurrentMana = -2f * Time.deltaTime;
    }
}
