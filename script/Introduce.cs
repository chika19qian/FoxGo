using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduce : MonoBehaviour
{
    public GameObject intro_text;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag=="Player")
        {
            intro_text.SetActive(true);
            
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            intro_text.SetActive(false);
        }   
    }
}
