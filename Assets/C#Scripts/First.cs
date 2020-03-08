using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    int a = 1;
    int b = 1;
    Rigidbody2D rb;
    void Start()
    {
    	rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject HitBOX = GameObject.CreatePrimitive(PrimitiveType.Cube);
            HitBOX.transform.localScale = new Vector2(10, 2);
            BoxCollider e = HitBOX.GetComponent<BoxCollider>();
            Destroy(e);
            HitBOX.AddComponent<BoxCollider2D>();
            HitBOX.AddComponent<HitBoxScrept>();
            
            BoxCollider2D box = HitBOX.GetComponent < BoxCollider2D>();
            
            if (transform.eulerAngles.y==0)
            {
                HitBOX.transform.position = new Vector3(transform.position.x+5, transform.position.y, transform.position.z);
                

            }
            if (transform.eulerAngles.y == 180)
            {
                HitBOX.transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);

            }
            
            
            

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles=new Vector3(0, 180.0f, 0);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 50f, ForceMode2D.Impulse);
           

        }
        if (Input.GetKeyDown(KeyCode.E)&&(a==1)){
            rb.AddForce(transform.up * 24f, ForceMode2D.Impulse);
            rb.AddForce(transform.right * 24f, ForceMode2D.Impulse);
            a = 0;
            b=0;
        }
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 20f, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        a = 1;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lader")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.transform.position.x, 20f);
            }
        }
    }
    //void FixUpdate(){
    //	rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb.velocity.y);
    //}
}
