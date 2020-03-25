using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class First : MonoBehaviour
{
    
    int a = 1;
    int b = 1;
    Rigidbody2D rb;
    Animator anim;
    public int hp;
    public float slash;
    public int coin;
    void Start()
    {
    	rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        slash += Time.deltaTime;
        GameObject Hp_lable = GameObject.Find("HP_canvas");
        Hp_lable.transform.position = new Vector2(transform.position.x + 8, transform.position.y + 10);
        GameObject Hp = GameObject.Find("HP_label");
        GameObject Coin = GameObject.Find("Coin");
        Coin.GetComponent<Text>().text = Convert.ToString(coin);
        Hp.GetComponent<Text>().text = Convert.ToString(hp);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject HitBOX = GameObject.CreatePrimitive(PrimitiveType.Cube);
            HitBOX.transform.localScale = new Vector3(10, 2, -100);
            BoxCollider e = HitBOX.GetComponent<BoxCollider>();
            Destroy(e);
            HitBOX.AddComponent<BoxCollider2D>();
            HitBOX.AddComponent<HitBoxScrept>();


            BoxCollider2D box = HitBOX.GetComponent<BoxCollider2D>();

            if (transform.eulerAngles.y == 0)
            {
                HitBOX.transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);


            }
            if (transform.eulerAngles.y == 180)
            {
                HitBOX.transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);

            }


        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("12312");
        }
        if (rb.velocity.magnitude!=0)
        {
            anim.SetInteger("test", 1);
        }
        else
        {
            anim.SetInteger("test", 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x<20)
            {
                rb.velocity = new Vector2(20f, rb.velocity.y);

            }
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -20)
            {
                rb.velocity = new Vector2(-20f, rb.velocity.y);
            }
                transform.eulerAngles=new Vector3(0, 180.0f, 0);

        }
        if (Input.GetKeyDown(KeyCode.Space)&&a==1)
        {
            Vector2 op = new Vector2(rb.velocity.x, 50);

            rb.velocity = op; 
            a = 0;
           

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (slash > 1 && a == 1)
            {
                if (transform.eulerAngles.y == 180f)
                {
                    Vector2 n = new Vector2(-70f, rb.velocity.y+25);
                    rb.AddForce(n, ForceMode2D.Impulse);
                    a = 0;

                }
                if (transform.eulerAngles.y == 0f)
                {
                    Vector2 n = new Vector2(70f, rb.velocity.y+25);
                    rb.AddForce(n, ForceMode2D.Impulse);
                    a = 0;
                }
                slash = 0;
            }
          
            b=0;
        }
        if (rb.velocity.x > 100)
        {
            rb.velocity =new Vector2(100,rb.velocity.y);

        }
        if (rb.velocity.x < -100)
        {
            rb.velocity = new Vector2(-100, rb.velocity.y);
        }
       
    }

    void FixedUpdate(){
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 20f, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        a = 1;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            coin += 1;
            Destroy(collision.gameObject);
            print(111);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lader")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(0, 20f);
            }
        }
        if (collision.gameObject.tag == "coin")
        { 
        
        }
    }


}
