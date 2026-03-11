using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    public ShopUppgrades shopUppgrades;
    public GameObject pausePanel;
    

    void Start()
    {
        pausePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && shopUppgrades.shopOpen == false)
        {


            if (isPaused == false)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                isPaused = true;
            }
            else 
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
                isPaused = false;
            }


        }

    }
}
