using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    public GameObject HPPrefab;
    public GameObject Shadow;
    public GameObject Shadow2;
    public GameObject M1;
    public int HP = 3;
    public CameraAnim CCamera;
    public float T;
    float T2;
    int a = 1;
    int UsingLadder = 0;
    Vector2 Slash;
    Rigidbody2D rb;
    Animator anim;
    public bool IsUp = false;
    float AtackReload;
    float SlashReload;
    float HpMinusReload;
    float ShadowCreate = 0.05f;


    void Start()
    {
    	rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(M1, new Vector3(transform.position.x, transform.position.y + 15, -15), Quaternion.identity);
        }
        if (T>-1)
        {
            T -= Time.deltaTime;
        }
        if (T2>-1)
        {
            T2 -= Time.deltaTime;
        }
        if (AtackReload > -1)
        {
            AtackReload -= Time.deltaTime;
        }
        if (SlashReload > -1)
        {
            SlashReload -= Time.deltaTime;
        }
        if (HpMinusReload > -1)
        {
            HpMinusReload -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q) && AtackReload < 0)
        {
            AtackReload = 0.3f;
            
            if (transform.eulerAngles.y == 180)
            {
                Instantiate(HPPrefab, new Vector3(transform.position.x - 8, transform.position.y, transform.position.z - 1), Quaternion.identity);
            }
            if (transform.eulerAngles.y == 0)
            {
                Instantiate(HPPrefab, new Vector3(transform.position.x + 3, transform.position.y, transform.position.z - 1), Quaternion.identity);
            }

        }
        if (rb.velocity.magnitude>2 && UsingLadder != 1)
        {
            anim.SetInteger("test", 1);
            if (CCamera.move != 6) { CCamera.move = 3; }
        }
        else if (UsingLadder!=1)
        {
            anim.SetInteger("test", 2);
            if (CCamera.move != 6) { CCamera.move = 5; }

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
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 78f, ForceMode2D.Impulse);
           

        }
        if (Input.GetKey(KeyCode.E) && T <= 0 && SlashReload < 0 && !IsUp)
        {
            rb.velocity = Vector2.zero;
            SlashReload = 1;
            Slash.x = -(transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
            Slash.y = -(transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            T = 0.4f;
            if (Slash.x < 0)
            {
                transform.eulerAngles = new Vector3(0, 180.0f, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (T > 0)
        {
            anim.SetInteger("test", 5);
            rb.AddForce(Slash.normalized * 500 * Time.deltaTime, ForceMode2D.Impulse);
            if (T2 < 0)
            {
                T2 = ShadowCreate;
                if (Slash.x < 0)
                {
                    Instantiate(Shadow2, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
                }
                else
                {
                    Instantiate(Shadow, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
                }
            }
        }
        else if (T < 0 && T > -0.1f)
        {
            rb.velocity = new Vector2(0, 0);
            T -= 2;
        }
        
    }
    
    void FixedUpdate(){
        if (!(T>0))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 20f, rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.tag == "Platform")
        {
            this.transform.parent = col.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            this.transform.parent = null;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lader")
        {
            if (UsingLadder == 1)
            {
                rb.velocity = new Vector2(0, 2);
                anim.SetInteger("test", 4);
            }
            if (Input.GetKey(KeyCode.S))
            {
                UsingLadder = 1;
                rb.velocity = new Vector2(rb.transform.position.x, -20f);
            }
            anim.SetInteger("test", 4);

            if (Input.GetKey(KeyCode.W))
            {
                UsingLadder = 1;
                rb.velocity = new Vector2(rb.transform.position.x, 20f);
                
            }
        }
        if (collision.gameObject.tag == "Bullet" && HpMinusReload<0)
        {
            HpMinusReload = 1;
            CCamera.hited = true;
            HP -= 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lader")
        {
            UsingLadder = 0;    
        }
    }
    //void FixUpdate(){
    //	rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb.velocity.y);
    //}
}
