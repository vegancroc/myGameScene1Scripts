using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    #region Fields
    public Animator carAnim;
    public dialogueSystem ds;

    Rigidbody2D rb;
    AudioSource audioSource;

    public Animator anim;

    [SerializeField]
    float speed;

    [SerializeField]
    float startEventTime;

    private float horizontalMove;
    
    private bool movePass = false;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        FindObjectOfType<soundManager>().playRain();
        Invoke("InvokeChangeMovePass", startEventTime);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    { 
        displayNextSentenceCheck();
    }

    #region Functions
    void Move()
    {
        if (movePass)
        { 
            checkIsMoving();
            horizontalMove = Input.GetAxis("Horizontal");
            Vector2 Horizontalforce = new Vector2(horizontalMove * Time.fixedDeltaTime * speed, rb.velocity.y);
            rb.velocity = Horizontalforce;
            CheckFlip();
        }
    }

    void CheckFlip()
    {
        if (horizontalMove <0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (horizontalMove >0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void checkIsMoving()
    {
        if (rb.velocity.x != 0)
        {
            if (!audioSource.isPlaying)
            { 
                audioSource.Play();
                anim.SetBool("isMoving", true);
            }
        }
        else
        {
            audioSource.Stop();
            anim.SetBool("isMoving", false);
        }
    }
    public void InvokeChangeMovePass()
    {
        movePass = true;
    }

    public void MovePass(bool value)
    {
        movePass = value;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "eventObject1")
        {
            carAnim.SetBool("carMovement", true);
            GameObject.Find("eventObject1").SetActive(false);
        }
    }

    void displayNextSentenceCheck()
    {
        if (ds.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ds.DisplayNextSentence();
            }
        }
    }
    #endregion
}
