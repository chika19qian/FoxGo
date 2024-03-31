using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opomove : Enemy
{
    public Rigidbody2D rb;
    public Animator anim;
    public Collider2D coll;
    public Transform leftpoint, rightpoint;
    public float speed;

    private float leftx, rightx;

    private bool faceleft = true;

    protected AudioSource deathAudio;



    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        deathAudio=GetComponent<AudioSource>();

        //transform.DetachChildren();
        leftx=leftpoint.position.x;
        rightx=rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {

        if(faceleft)
        {
            rb.velocity=new Vector2(-speed,rb.velocity.y);
            if(transform.position.x < leftx)
            {
                transform.localScale=new Vector3(-1,1,1);
                faceleft = false;
            }
        }
        else
        {
            rb.velocity=new Vector2(speed,rb.velocity.y);
            if(transform.position.x > rightx)
            {
                transform.localScale=new Vector3(1,1,1);
                faceleft = true;
            }
        }
    }
    
    
}
