using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int UsingLadder = 0;
    Vector2 Slash;
    Rigidbody2D rb;
    Animator anim;
    public bool IsUp = false;
    float AtackReload;
    float SlashReload;
    float HpMinusReload;
    float ShadowCreate = 0.05f;
    public int coin;
    public int Wood;
    public int Iron;
    public int Stone;
    public bool ispause = false;
    public GameObject UI;
    public GameObject Sword;
    public bool isopenBlade = false;
    public GameObject MapCanvas = null;
    public float DashSpeed=500;
    public float JumpPower = 78;
    public float DefaultDamage = 1;
    public float Damage = 1;
    public float WalkSpeed = 20;
    data s;
    ForSaves saves;
    public float[] DamageModify = { 1, 1, 1 };
    public GameObject Dead;
    public GameObject Vhod;
    void Start()
    {
        Vhod.SetActive(true);
        s = this.gameObject.GetComponent<ForSaves>().MyData;
        Iron = s.iron;
        Wood = s.wood;
        Stone = s.rock;
        coin = s.coin;
        saves = gameObject.GetComponent<ForSaves>();
        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        Damage = DefaultDamage * DamageModify[2];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispause == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
        if (Input.GetKeyDown(KeyCode.R)&&isopenBlade)
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
        if (Input.GetKey(KeyCode.Q) && AtackReload < 0 && UsingLadder != 1)
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
        if (Input.GetKeyDown(KeyCode.Space)&& a==1)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * JumpPower, ForceMode2D.Impulse);
            a = 0;
           

        }
        if (Input.GetKey(KeyCode.E) && T <= 0 && SlashReload < 0 && !IsUp)
        {
            UsingLadder = 0;
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
            if (IsUp)
            {
                T = 0;
            }

            rb.AddForce(Slash.normalized * DashSpeed * Time.deltaTime, ForceMode2D.Impulse);
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
        if (rb.velocity.x>0)
        {
            transform.eulerAngles= new Vector2 (0,0);
        }
        if (rb.velocity.x < 0)
        {
            transform.eulerAngles = new Vector2(0, -180);
        }
        if (HP <= 0)
        {
            
            StartCoroutine(MYLVL(1));
            



        }

    }
    
    void FixedUpdate(){
        if (!(T>0))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * WalkSpeed, rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Wall")
        {
            a = 1;
        }
        
        if (col.gameObject.tag == "Platform")
        {
            this.transform.parent = col.transform;
        }
        if (col.gameObject.tag == "Wood")
        {
            Wood += 1;
            
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Iron")
        {
            Iron += 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Stone")
        {
            Stone += 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Coin")
        {
            coin += 1;
            Destroy(col.gameObject);
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

        if (collision.gameObject.tag == "Lader"&& T<0)
        {
            
            if (UsingLadder == 1)
            {
                Sword.SetActive(false);
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
            Damage = DefaultDamage * DamageModify[HP - 1];
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lader")
        {
            UsingLadder = 0;    
        }
        Sword.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        UI.SetActive(true);
        ispause = true;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        UI.SetActive(false);
        ispause = false;
    }
    public void Exit()
    {
        StartCoroutine(MYLVL(0));
        
        Time.timeScale = 1;
        ispause = false;
    }
    private void Loadlvl()
    {
        

    }
    IEnumerator MYLVL(int numb)
    {
        Dead.SetActive(true);
        yield return new WaitForSeconds(2);
        
        Destroy(gameObject);
        Application.LoadLevel(numb);
    }
    //void FixUpdate(){
    //	rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb.velocity.y);
    //}
}
