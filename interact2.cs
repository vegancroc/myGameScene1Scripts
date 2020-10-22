using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact2 : MonoBehaviour
{

    #region Fields
    public dialogueSystem ds;

    [TextArea(3, 10)]
    public string[] Sentences;

    [Header("Npc Give Settings (NOT SET YET)")]
    public float Give;  //NOT IN USE
    #endregion

    #region Functions
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player")
        {
            ds.gameObject.SetActive(true);
            FindObjectOfType<character>().MovePass(false);
            FindObjectOfType<character>().anim.SetBool("isMoving", false);
            ds.StartDialogue(Sentences);
        }
    }

    #endregion
}
