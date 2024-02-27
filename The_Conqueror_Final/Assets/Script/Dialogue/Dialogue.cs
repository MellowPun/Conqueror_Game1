using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject tutorialBox=null;

    [SerializeField] private TMP_Text textLabelDia;
    [SerializeField] private TMP_Text textLabelTut = null;

    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] private DialogueObject tutorialDialogue = null;

    private TypeWriter typeWriterEffect;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriter>();
        CloseDialogue();
        ShowDialogue(testDialogue, tutorialDialogue);
    }
    public void ShowDialogue(DialogueObject dialogueObject, DialogueObject dialogueTut)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject, dialogueTut));

    }
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject, DialogueObject dialogueTut)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typeWriterEffect.Run(dialogue, textLabelDia);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        }
        dialogueBox.SetActive(false);
        if (tutorialBox != null&& textLabelTut !=null)
        {
            tutorialBox.SetActive(true);
            foreach (string dialogue in dialogueTut.Dialogue)
            {
                yield return typeWriterEffect.Run(dialogue, textLabelTut);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            }
            if (SceneManager.sceneCount >= SceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        


    }

    private void CloseDialogue()
    {
        dialogueBox.SetActive(false);
        tutorialBox.SetActive(false);
        textLabelDia.text = string.Empty;
        textLabelTut.text = string.Empty;
    }
    

}
