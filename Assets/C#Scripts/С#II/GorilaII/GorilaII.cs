using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorilaII : MonoBehaviour
{
    public float HP = 10;
    public GameObject dead;
    public GameObject pl;
    public float TimeOfReload;
    Vector2 direction;
    public float maxX;
    public float minX;
    public float LeftEndRangeX;
    public float RightEndRangeX;
    public float speed;
    float WherwToAtack;
    public bool Atacking;
    bool IsLeftA;
    public bool SA;
    bool IsGoLeft = false;
    public bool MayAtack;
    float t = 0;
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
        if (SA)
        {
            SA = false;
            StartAtack();
        }
        if (Atacking)
        {
            anim.SetInteger("M", 2);
            Atack();
        }
        else if (t <= 0 && !Atacking)
        {
            if (IsGoLeft == false)
            {
                anim.SetInteger("M", 0);
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
                anim.SetInteger("M", 0);
                transform.Translate(direction * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180.0f);
                if (transform.position.x < minX)
                {
                    IsGoLeft = false;
                    t = 3;
                }
            }
        }
        else
        {
            anim.SetInteger("M", 1);
            t -= Time.deltaTime;
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
                rb.AddForce(transform.up * 30, ForceMode2D.Impulse);
            }
            else
            {
                Instantiate(dead, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    void BecomeWhite()
    {
        sr.color = Color.white;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Atacking)
        {
            MayAtack = true;
            StartAtack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MayAtack = false;
        }
    }
    void StartAtack()
    {
        if (transform.position.x < pl.transform.position.x)
        {
            IsLeftA = false;
            Atacking = true;
            WherwToAtack = RightEndRangeX;
        }
        else
        {
            IsLeftA = true;
            Atacking = true;
            WherwToAtack = LeftEndRangeX;
        }
    }
    void Atack()
    {
        if (!IsLeftA)
        {
            transform.Translate(direction * speed * 2 * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            if (transform.position.x> WherwToAtack)
            {
                t = 5;
                Atacking = false;
            }
        }
        else
        {
            transform.Translate(direction * speed * 2 * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
            if (transform.position.x < WherwToAtack)
            {
                t = 5;
                Atacking = false;
            }
        }

    }
}
