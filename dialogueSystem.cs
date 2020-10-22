using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueSystem : MonoBehaviour
{
    #region Fields
    public TextMeshProUGUI dialogueText;
    public Animator animator;

    [SerializeField]
    private float delayBetweenLetters;

    [SerializeField]
    private float letterVolume;

    private Queue<string> sentences;
    #endregion

    void Awake()
    {
        sentences = new Queue<string>();
    }

    #region Functions
    public void StartDialogue(string[] Sentences)
    {
        animator.SetBool("isOpen", true);
        //if (sentences!=null && Sentences != null)
        //{
            sentences.Clear();
        //}
        //else if(sentences ==null & Sentences ==null)
        //{
           // DisplayNextSentence();
        //}
        foreach (string sentence in Sentences)
        {
            //if (sentences!=null && Sentences !=null)
            //{
                sentences.Enqueue(sentence);
            //}
            //else if (sentences == null & Sentences == null)
            //{
                //DisplayNextSentence();
            //}
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences != null)
        {

            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
        }
        if (sentences != null)
        {


            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            FindObjectOfType<soundManager>().playVoice1(letterVolume);
            yield return new WaitForSecondsRealtime(delayBetweenLetters);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        FindObjectOfType<character>().MovePass(true);
        //FindObjectOfType<character>().invisibleFloat = 1;
        gameObject.SetActive(false);
    }
    #endregion 
}
