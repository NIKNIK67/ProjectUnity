using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkayJ : MonoBehaviour
{
    float HP = 10;
    public GameObject pl;
    public GameObject BilletPref;
    public GameObject SmokePref;
    Vector2 direction;
    public float maxX;
    public float minX;
    public float LeftEndRangeX;
    public float RightEndRangeX;
    public float speed;
    public float WherwToAtack;
    public bool Atacking;
    bool IsLeftA;
    public bool SA;
    bool IsGoLeft = false;
    public bool MayAtack;
    public float RangeOfAngry;
    public float RangeOfatack;
    public float RangeOfScare;
    float t = 0;
    public float t2 = 2;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        direction.x = 1;
    }
    void Update()
    {
        t -= Time.deltaTime;
        t2 -= Time.deltaTime;
        if (t2 < 3.7f)
        {
            Atacking = false;
        }
        if (3<t2 && t2 < 3.4)
        {
            anim.SetInteger("M", 1);
        }
        GoToPl();
        if (SA && t2<0)
        {
            SA = false;
            StartAtack();
            StartAtack2();
        }
        if (t <= 0 && !Atacking && !(Mathf.Abs(pl.transform.position.x - transform.position.x) < RangeOfAngry) &&  Mathf.Abs(pl.transform.position.y - transform.position.y) > 10)
        {
            if (IsGoLeft == false)
            {
                anim.SetInteger("M", 2);
                transform.Translate(direction * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
                if (transform.position.x > maxX)
                {
                    IsGoLeft = true;
                    t = 3;
                }
            }
            else
            {
                anim.SetInteger("M", 2);
                transform.Translate(direction * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180.0f);
                if (transform.position.x < minX)
                {
                    IsGoLeft = false;
                    t = 3;
                }
            }
        }
        else if(Mathf.Abs(pl.transform.position.x - transform.position.x) > RangeOfAngry)
        {
            anim.SetInteger("M", 1);
        }
    }
    void StartAtack()
    {
        if (transform.position.x < pl.transform.position.x)
        {
            IsLeftA = false;
            Atacking = true;
        }
        else
        {
            IsLeftA = true;
            Atacking = true;
        }
    }
    void StartAtack2()
    {
        if (!IsLeftA && t2 < 0)
        {
            anim.SetInteger("M", 0);
            transform.eulerAngles = new Vector2(0, 0);
            rb.AddForce(transform.right * 500, ForceMode2D.Impulse);
            Atacking = true;
            t2 = 4;
            Invoke("AtackB", 0.5f);
        }
        else if (t2 < 0)
        {
            anim.SetInteger("M", 0);
            transform.eulerAngles = new Vector2(0, 180);
            rb.AddForce(transform.right * 500, ForceMode2D.Impulse);
            if (transform.position.x < WherwToAtack)
                Atacking = true;
            t2 = 4;
            Invoke("AtackB", 0.5f);
        }

    }
    void AtackB()
    {
        if (!IsLeftA)
        {
            transform.eulerAngles = new Vector2(0, 0);
            rb.AddForce(-transform.right * 500, ForceMode2D.Impulse);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            rb.AddForce(-transform.right * 500, ForceMode2D.Impulse);

        }

    }
    void GoToPl()
    {
        if (t2 < 0)
            if (Mathf.Abs(pl.transform.position.x - transform.position.x) < RangeOfatack && !(Mathf.Abs(pl.transform.position.x - transform.position.x) < RangeOfScare && !Atacking) && Mathf.Abs(pl.transform.position.y - transform.position.y) < 10)
            {
                if (transform.position.x - pl.transform.position.x >= 0)
                {
                    transform.eulerAngles = new Vector2(0, 180);
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                else
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                anim.SetInteger("M", 2);
            }
        else
        {
            if (Mathf.Abs(pl.transform.position.x - transform.position.x) < RangeOfatack && !Atacking && Mathf.Abs(pl.transform.position.y - transform.position.y) < 10)
            {
                if (transform.position.x - pl.transform.position.x >= 0)
                {
                    transform.eulerAngles = new Vector2(0, 180);
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                else
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    transform.Translate(direction * speed * Time.deltaTime);
                }
            }
            anim.SetInteger("M", 2);
        }

            if (Mathf.Abs(pl.transform.position.x - transform.position.x) < RangeOfScare && !Atacking && t2>0 && Mathf.Abs(pl.transform.position.y - transform.position.y) < 10)
            {
                if (transform.position.x - pl.transform.position.x >= 0)
                {

                transform.eulerAngles = new Vector2(0, 180);
                    transform.Translate(-direction * speed * Time.deltaTime);
                }
                else
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    transform.Translate(-direction * speed * Time.deltaTime);
                }
                anim.SetInteger("M", 3);
            }
        }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("HPPrefab"))
        {
            sr.color = Color.red;
            HP -= 1;
            Invoke("BecomeWhite", 0.2f);
            if (HP > 0)
            {
                rb.AddForce(transform.up * 300, ForceMode2D.Impulse);
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