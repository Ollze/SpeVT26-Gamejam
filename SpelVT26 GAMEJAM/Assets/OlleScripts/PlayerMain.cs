using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float moveSpeed = 5;
    public ParticleSystem shootParticles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed) { transform.position += new Vector3(0, 1, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.sKey.isPressed) { transform.position += new Vector3(0, -1, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.dKey.isPressed) { transform.position += new Vector3(1, 0, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.aKey.isPressed) { transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime; }
        if (Mouse.current.leftButton.isPressed)
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        shootParticles.Play();
    }
}
