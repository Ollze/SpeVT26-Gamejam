using UnityEngine;

public class MoonParallax : MonoBehaviour
{
    public Transform player;
    public float parallaxFactor = 0.1f;

    private Vector3 lastPlayerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPlayerPosition = player.position;   
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = player.position - lastPlayerPosition;
        transform.position += -deltaMovement * parallaxFactor;
        lastPlayerPosition = player.position;
    }
}
