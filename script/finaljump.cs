using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finaljump : MonoBehaviour
{
/*    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;


    public float speed, jumpforce;

    public Transform groundCheck;
    public LayerMask ground;

    public bool isGround, isJump;
    bool jumpPressed;
    int jumpCount;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll=GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")&&jumpCount>0)
        
        {
            jumpPressed=true;
        }
        Jump()
    }

    private void FixedUpdate()
    {
        
        isGround=Physics2D.OverlapCircle(groundCheck.position,0.1f,ground);
        Groundmove()
    }

    void Groundmove()
    {
        float horizontalmove = Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(horizontalmove*speed, rb.velocity.y);

        if(horizontalmove != 0)
        {
            transform.localScale=new Vector3(horizontalmove,1,1);
        }
    }

    void Jump()
    {
        if(isGround)
        {
            jumpCount=2;
            isJump=false;
        }
        if(jumpPressed && isGround)
        {
            isJump=true;
            rb.velocity=new Vector2(rb.velocity.x, jumpforce);
            jumpCount--;
            jumpPressed = false;
        }
    }*/
}
