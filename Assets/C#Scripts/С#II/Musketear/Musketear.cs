using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musketear : MonoBehaviour
{
    public GameObject Coin;
    public float HP = 10;
    public GameObject pl;
    public GameObject BilletPref;
    public GameObject SmokePref;
    public GameObject SmokePref2;
    public float TimeOfReload;
    public float t2;
    Vector2 direction;
    public float maxX;
    public float minX;
    public float speed;
    bool IsGoLeft = false;
    public float ttest;
    public bool leighOfangry;
    public float RangeOfAngry;
    public float RangeOfatack;
    public float RangeOfScare;
    float t = 0;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    First Damage;
    void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        maxX = transform.position.x + 20;
        minX = transform.position.x - 20;
        pl = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        direction.x = 1;
    }
    void Update()
    {
        if (t2 >= 0)
        {
            t2 -= Time.deltaTime;
        }
        if (Mathf.Abs(pl.transform.position.x - transform.position.x) < RangeOfAngry && Mathf.Abs(pl.transform.position.y - transform.position.y) < 30)
        {

            if (Mathf.Abs(pl.transform.position.x - transform.position.x) > RangeOfatack)
            {
                if (transform.position.x - pl.transform.position.x <= 0)
                {
                    transform.eulerAngles = new Vector2(0, 0f);
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                else
                {
                    transform.eulerAngles = new Vector2(0, 180f);
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                anim.SetInteger("Mus", 0);
            }
            else if (Mathf.Abs(pl.transform.position.x - transform.position.x) < RangeOfScare)
            {
                if (transform.position.x - pl.transform.position.x >= 0)
                {
                    transform.eulerAngles = new Vector2(0, 0f);
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                else
                {
                    transform.eulerAngles = new Vector2(0, 180f);
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                anim.SetInteger("Mus", 0);
            }
            else
            {
                anim.SetInteger("Mus", 1);
            }
            if (Mathf.Abs(pl.transform.position.x - transform.position.x) < RangeOfatack && Mathf.Abs(pl.transform.position.x - transform.position.x) > RangeOfScare)
            {
                if (transform.position.x - pl.transform.position.x <= 0)
                {
                    transform.eulerAngles = new Vector2(0, 0f);
                }
                else
                {
                    transform.eulerAngles = new Vector2(0, 180f);
                }
               
                if (t2 <= 0) {
                    if (transform.position.x - pl.transform.position.x <= 0)
                    {
                        Instantiate(SmokePref, new Vector3(transform.position.x + 3, transform.position.y - 2, transform.position.z - 1), Quaternion.identity);
                        Instantiate(BilletPref, new Vector3(transform.position.x + 3, transform.position.y - 2, transform.position.z - 1), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(SmokePref2, new Vector3(transform.position.x - 3, transform.position.y - 2, transform.position.z - 1), Quaternion.identity);
                        Instantiate(BilletPref, new Vector3(transform.position.x - 3, transform.position.y - 2, transform.position.z - 1), Quaternion.identity);
                    }
                    t2 = TimeOfReload;

                } 
                
            }
        }
        else {
            if (t <= 0)
            {
                anim.SetInteger("Mus", 0);
                if (IsGoLeft == false)
                {

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
                anim.SetInteger("Mus", 1);
                t -= Time.deltaTime;
            }
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
                rb.AddForce(transform.up * 300, ForceMode2D.Impulse);
            }
            else
            {
                int RandomVar;
                RandomVar = Random.Range(5, 10);
                for (int i=0;i< RandomVar; i += 1)
                {
                    Instantiate(Coin, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
    void BecomeWhite()
    {
        sr.color = Color.white;
    }
}
