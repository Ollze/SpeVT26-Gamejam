using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuOpenSound()
    {
        audioSource.Play();
    }
}