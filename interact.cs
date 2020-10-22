using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    #region Fields
    public dialogueSystem ds;

    [SerializeField]
    private KeyCode interactionKey;

    [SerializeField]
    private KeyCode skipSentenceKey;

    [TextArea(3, 10)]
    public string[] Sentences;

    [Header("Npc Give Settings (NOT SET YET)")]
    public float Give;  //NOT IN USE

    private bool isInteract = false;

    #endregion

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player")
        {
            isInteract = true;
        }
    }

    void Update()
    {
        CheckKey();
        if (ds.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(skipSentenceKey))
            {
                ds.DisplayNextSentence();
            }
        }
    }

    #region Functions
    void CheckKey()
    { 
        if (isInteract)
        {
            if (Input.GetKeyDown(interactionKey))
            {
                ds.gameObject.SetActive(true);
                FindObjectOfType<character>().MovePass(false);
                ds.StartDialogue(Sentences);
                isInteract = false;
            }
        }
    }
    #endregion
}



