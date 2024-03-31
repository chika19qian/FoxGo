using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_move : MonoBehaviour
{
    public static Platform_move instance{get; set; }

    public Collider2D coll;
    public Rigidbody2D rb;
    public Transform uppoint, downpoint;

    public float speed;
    public float distance;
    public bool moving;
    public Vector3 destination;

    
    // Start is called before the first frame update
    void Start()
    {   
        

        distance=Vector2.Distance(gameObject.transform.position, destination);


        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    // Update is called once per frame
    public void upping()
    {   
        
        if(moving==true)
        {
            transform.position=Vector2.MoveTowards(gameObject.transform.position,destination,speed*Time.deltaTime);
        }
        

        if(gameObject.transform.position == destination)
        {
            moving=false;
        }
        
    }


}
