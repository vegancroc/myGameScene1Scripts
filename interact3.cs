using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact3 : MonoBehaviour
{
    #region Fields
    public dialogueSystem ds;

    [SerializeField]
    private bool isOpenMoreThanOnce;

    [TextArea(3, 10)]
    public string[] Sentences;

    [Header("Npc Give Settings (NOT SET YET)")]
    public float Give;  //NOT IN USE
    #endregion

    #region OnTrigger
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "player")
        {
            ds.gameObject.SetActive(true);
            FindObjectOfType<character>().MovePass(false);
            FindObjectOfType<character>().anim.SetBool("isMoving", false);
            ds.StartDialogue(Sentences);
            gameObject.GetComponent<Rigidbody2D>().gameObject.SetActive(isOpenMoreThanOnce);
        }
    }

    #endregion
}
