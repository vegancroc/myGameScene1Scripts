using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScene : MonoBehaviour
{
    #region Fields
    public soundManager sm;

    public AudioSource audios;

    public Animator anim;

    public Animator anim2;

    [SerializeField]
    private float lightningTime;

    [SerializeField]
    private float loadSceneTime;

    [SerializeField]
    private float FadeTime;

    [SerializeField]
    private float blackTime;
    #endregion

    void Start()
    {
        Invoke("playAnim", lightningTime);
    }

    #region Functions
    void playAnim()
    {
        anim.SetBool("openAnim",true);
    }

    void Update()
    {
       
        if (anim.GetBool("openAnim"))
        {
            if (!audios.isPlaying)
            {
                audios.Play();
            }
            Invoke("playFade", FadeTime);
        }
        if (anim.GetBool("openFade"))
        {
            Invoke("playBlack", blackTime);
        }
        if (anim2.GetBool("blackplay"))
        {
            Invoke("startNextScene", loadSceneTime);
        }
    }

    void startNextScene()
    {
        FindObjectOfType<menu>().loadScene(1);
    }

    void playFade()
    {
        anim.SetBool("openFade", true);
    }

    void playBlack()
    {
        anim2.SetBool("blackplay", true);
    }
    #endregion
}
