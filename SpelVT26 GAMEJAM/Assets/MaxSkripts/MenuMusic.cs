using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource lobbyAudio;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuOpenSound()
    {
        audioSource.Play();
    }

    public void StopMenuOpenSound()
    {
        audioSource.Stop();
    }

    public void PlaylobbyAudio()
    {
        lobbyAudio.Play();
    }

    public void StoplobbyAudio()
    {
        lobbyAudio.Stop();
    }
    
}