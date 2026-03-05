using UnityEngine;

public class RotateUp : MonoBehaviour
{
    private Transform parentRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        parentRotation = transform.parent;
    }

    void Update()
    {
        //Quaternion parentRot = parentRotation.rotation;
        float z = parentRotation.rotation.z;
        //z += transform.rotation.eulerAngles.z;
        transform.rotation = new Quaternion(0,0, -z,0);
    }
}
