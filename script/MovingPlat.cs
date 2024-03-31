using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public Transform uppoint, downpoint;
    public float speed;

    private float upy, downy;

    private bool up_fly = true;



    // Start is called before the first frame update
    void Start()
    {
        upy=uppoint.position.y;
        downy=downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {

        if(up_fly)
        {
            rb.velocity=new Vector2(rb.velocity.x,speed);
            if(transform.position.y > upy)
            {

                up_fly = false;
            }
        }
        else
        {
            rb.velocity=new Vector2(rb.velocity.x,-speed);
            if(transform.position.y < downy)
            {

                up_fly = true;
            }
        }
    }

    
}
