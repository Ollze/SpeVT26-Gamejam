using UnityEngine;

public class PlayerAwarement : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float playerAwernessDistance;

    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMain>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerAwernessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }

        if (enemyToPlayerVector.x < 0f)
        {
            transform.rotation = new Quaternion(0, 0, -1f, 0);
        }
    }
}
