using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected AudioSource deathAudio;

    protected virtual void Start() 
    {
        anim=GetComponent<Animator>();
        deathAudio=GetComponent<AudioSource>();
    }

    public void die()
    {
        
        Destroy(gameObject);
    }

    public void JumpOn()
    {
        
        anim.SetTrigger("die");
        deathAudio.Play();
    }

}
