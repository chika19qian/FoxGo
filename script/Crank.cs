using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{
    

    public Animator anim;
    public Collider2D coll;
    


    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag=="Player")
        {
            
            
            if(transform.position.x>collision.gameObject.transform.position.x)
            {
                
                anim.SetBool("isup",true);
                anim.SetBool("isdown",false);
                
            }

            if(transform.position.x<collision.gameObject.transform.position.x)
            {
                
                anim.SetBool("isup",false);
                anim.SetBool("isdown",true);
            }
            
        }   
    }

    void Update()
    {
        
    }

    void functioning()
    {
        
        GameObject.Find("Function_envi/platform").GetComponent<Platform_move>().moving=true;
        GameObject.Find("Function_envi/platform").GetComponent<Platform_move>().upping();
    }






}
