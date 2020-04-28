using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    First Damage;
    public float HP = 8;
    public GameObject pl;
    public GameObject BilletPref;
    public GameObject SmokePref;
    public GameObject SmokePref2;
    public float TimeOfReload;
    public float t2;
    bool a;
    public bool MayShoot;
    public float pe; 
    public Vector2 LefPos;
    public Vector2 RightPos;
    public Vector2 NextPos;
    public float height;
    float HS=0;
    public float speed;
    public bool leighOfangry;
    public float RangeOfAngry;
    public float RangeOfatack;
    public float RangeOfScare;
    float t = 0;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        LefPos = new Vector2(transform.position.x-20, transform.position.y+10);
        RightPos = new Vector2(transform.position.x+20, transform.position.y-10);
        pl = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        MYRand();


    }
    void Update()
    {
        WithPlayerMove();
        Poshativanie();
        if (t<=0 && a!=true) 
        {
            if (transform.position.x > NextPos.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            transform.position = Vector2.MoveTowards(transform.position, NextPos, speed * Time.deltaTime);
        }
        else if(a != true)
        {
            t -= Time.deltaTime;
        }
        if (transform.position.x== NextPos.x && transform.position.y == NextPos.y)
        {
            t = 2;
            MYRand();
        }
    }      
    void MYRand()
    { 
        NextPos.x = Random.Range(LefPos.x, RightPos.x);
        NextPos.y = Random.Range(RightPos.y, LefPos.y);
    }
    void Poshativanie()
    {
        if (height >= 0) 
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (2 * Time.deltaTime));
            HS += (4 * Time.deltaTime);
            if (HS > height)
            {
                height *= -1;
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (2 * Time.deltaTime));
            HS -= (2 * Time.deltaTime);
            if (HS < height)
            {
                height *= -1;
            }
        }
    }
    void WithPlayerMove()
    {
        pe = Mathf.Sqrt(Mathf.Abs(pl.transform.position.x - transform.position.x)* Mathf.Abs(pl.transform.position.x - transform.position.x) + Mathf.Abs(pl.transform.position.y - transform.position.y)*Mathf.Abs(pl.transform.position.y - transform.position.y));
        if (pe < RangeOfAngry)
        {
            if (transform.position.y - 20 < pl.transform.position.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + 2), speed * 2 * Time.deltaTime);
            }
            if (transform.position.y  > pl.transform.position.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - 2), speed * 2 * Time.deltaTime);
            }
            a = true;
            if(pe> RangeOfatack)
            {
                isLeft();
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - (transform.position.x - pl.transform.position.x), transform.position.y), speed * Time.deltaTime);
                if (transform.position.y - 3 < pl.transform.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + 2), speed*2 * Time.deltaTime);
                }
                MayShoot = false;
            }
            else if (pe < RangeOfScare)
            {
                isLeft();
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + (transform.position.x - pl.transform.position.x), transform.position.y+3), speed * Time.deltaTime);
                MayShoot = false;
            }
            else
            {
                MayShoot = true;
            }
        }
        else
        {
            MayShoot = false;
            isLeft();
            a = false;
        }
    }
    void isLeft()
    {
        if (transform.position.x > pl.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("HPPrefab"))
        {
            sr.color = Color.red;
            HP -= Damage.Damage;
            Invoke("BecomeWhite", 0.2f);
            if (HP > 0)
            {
                rb.AddForce(transform.up * 0, ForceMode2D.Impulse);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    void BecomeWhite()
    {
        sr.color = Color.white;
    }
}
