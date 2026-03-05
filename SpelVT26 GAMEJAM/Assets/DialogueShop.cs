using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class DialogueShop : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public string[] dialogueOptions;
    public float typeSpeed;
    private Coroutine typingRoutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            string randomLine = dialogueOptions[Random.Range(0, dialogueOptions.Length)];

            if (typingRoutine != null)
                StopCoroutine(typingRoutine);

            typingRoutine = StartCoroutine(TypeText(randomLine));
        }
    }

    IEnumerator TypeText(string line)
    {
        dialogueText.text = "";

        foreach (char c in line)
        { 
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(typeSpeed);
        }
    }
}
