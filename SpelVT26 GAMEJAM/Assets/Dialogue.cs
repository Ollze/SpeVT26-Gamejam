using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;
    private int index = 0;
    public UnityEngine.UI.Image[] characterImages;
    public int[] speakerIndex;
    public Animator[] characterAnimators;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        UpdatePortraits();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
           
            UpdatePortraits();
            StartCoroutine(TypeLine());

        }
        else
        {

            dialogueText.gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
    }

    void UpdatePortraits()
    {
        for (int i = 0; i < characterImages.Length; i++)
        {
            bool isSpeaker = (i == speakerIndex[index]);

            characterImages[i].color = isSpeaker ? Color.white : new Color(1f, 1f, 1f, 0.3f);

            if (characterAnimators != null && characterAnimators.Length > i)
            {
                characterAnimators[i].ResetTrigger("Bounce");
                characterAnimators[i].ResetTrigger("Bounce2");

                if (isSpeaker)
                {
                    if (i == 0)
                    {
                        characterAnimators[i].SetTrigger("Bounce");

                    }

                    if (i == 1)
                    {
                        characterAnimators[i].SetTrigger("Bounce2");
                    }
                }
                

            }
        }
    }
}
