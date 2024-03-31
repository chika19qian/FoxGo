using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enter_dialog : MonoBehaviour
{
    public GameObject entertext;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag=="Player")
        {
            entertext.SetActive(true);
            
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            entertext.SetActive(false);
        }   
    }

    
}
