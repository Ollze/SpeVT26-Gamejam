using UnityEngine;

public class shopPointer : MonoBehaviour
{
    private Vector3 shopPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopPos = GameObject.Find("Shop").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = shopPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        float distance = Vector3.Distance(shopPos, transform.position);
        //print(distance);
        if (distance < 10f)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

    }
}
