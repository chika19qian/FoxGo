using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Animator anim;

    public Collider2D coll;
    public Collider2D Discoll;

    public float speed;
    public float jumpforce;
    public LayerMask ground;
    public float health;

    public AudioSource jumpa;
    public AudioSource hurta;
    public AudioSource getGem;
    public AudioSource getCherry;
    public AudioSource dead;//还没添加

    public int Cherry;
    public int Gem;

    public Text CherryNum;
    public Text GemNum;
    public Text HealthNum;

    private bool isHurt;
    

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isHurt)
        {Move();}
        
        SwitchAnim();

    }



    void Move()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedircetion = Input.GetAxisRaw("Horizontal");

        //角色移动
        if (horizontalmove != 0)
        {
            rb.velocity=new Vector2(horizontalmove*speed * Time.fixedDeltaTime,rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedircetion));
        }
        if (facedircetion != 0)
        {
            transform.localScale = new Vector3(facedircetion, 1, 1);
        }

        //角色跳跃
        if (Input.GetButtonDown ("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpforce * Time.fixedDeltaTime);
            jumpa.Play();
            anim.SetBool("jumping",true);
            anim.SetBool("idle",false);
        }
        
        Crouch();

    }


    void Crouch()
    {
        //角色匍匐前进
        if (Input.GetButtonDown ("Crouch"))
        {
            anim.SetBool("crouching",true);
            Discoll.enabled = false;
        }
        else if(Input.GetButtonUp ("Crouch"))
        {
            anim.SetBool("crouching",false);
            Discoll.enabled = true;
        }
    }
    //切换动画
    void SwitchAnim()
    {
        if(rb.velocity.y<0.1f && !coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling",true);
        }
        
        if(anim.GetBool("jumping"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("jumping",false);
                anim.SetBool("falling",true);
            }
        }
        else if(isHurt)
        {
            anim.SetBool("hurting",true);
            anim.SetFloat("running",0);
            if(Mathf.Abs(rb.velocity.x)<0.1f)
            {
                anim.SetBool("hurting",false);
                anim.SetBool("idle",true);
                isHurt=false;
            }
        }
        else if(coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling",false);
            anim.SetBool("idle",true);
        }
    }

    //碰撞触发器
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //收集物品
        if(collision.tag=="collection")
        {
            Destroy(collision.gameObject);
            Discoll.enabled = false;
            Cherry+=1;
            CherryNum.text=Cherry.ToString();
            getCherry.Play();
            Discoll.enabled = true;
            
        }

        if(collision.tag=="gem")
        {
            Destroy(collision.gameObject);
            Discoll.enabled = false;
            Gem+=1;
            GemNum.text=Gem.ToString();
            getGem.Play();
            Discoll.enabled = true;

            health+=1f;
            HealthNum.text=health.ToString();
            
        }
        //死亡
        if(collision.tag=="deadline")
        {
            GetComponent<AudioSource>().enabled=false;
            Invoke("restart",2f);
        }

        

        
    }


    //打青蛙
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag=="enemy")
        {

            Enemy enemy=collision.gameObject.GetComponent<Enemy>();
            


            if(anim.GetBool("falling"))
            {
                //调用青蛙的函数
                enemy.JumpOn();

                rb.velocity=new Vector2(rb.velocity.x,jumpforce * Time.fixedDeltaTime);
                anim.SetBool("jumping",true);
            }
            else
            {
                
                
                if(transform.position.x<collision.gameObject.transform.position.x)
                {
                    rb.velocity=new Vector2(-10,rb.velocity.y);
                    hurta.Play();
                    isHurt=true;
            
                }
                else if(transform.position.x>collision.gameObject.transform.position.x)
                {
                    rb.velocity=new Vector2(10,rb.velocity.y);
                    hurta.Play();
                    isHurt=true;
                
                }
                health-=1f;
                HealthNum.text=health.ToString();

            } 
            
        }
        if(health<=0)
        {
            GetComponent<AudioSource>().enabled=false;
            Invoke("restart",1f);
        }
        
    }

    void restart()
    {
        //死亡        
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
        
        
    }


}
