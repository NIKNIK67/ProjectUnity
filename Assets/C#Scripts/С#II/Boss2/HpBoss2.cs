using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HpBoss2 : MonoBehaviour
{
    public GameObject Coin;
    public float HP = 10;
    public GameObject pl;
    Rigidbody2D rb;
    SpriteRenderer sr;
    First Damage;
    void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        pl = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("HPPrefab"))
        {
            sr.color = Color.red;
            if (this.GetComponent<Boss>().HP > 100)
            {
                this.GetComponent<Boss>().HP -= Damage.Damage;
            }
            else if (this.GetComponent<Boss>().HP <= 100 && this.GetComponent<Boss>().HP > 50)
            {
                this.GetComponent<Boss>().HP -= (Damage.Damage)/2;
            }
            else if (this.GetComponent<Boss>().HP <= 50)
            {
                this.GetComponent<Boss>().HP -= (Damage.Damage) / 4;
            }
            Invoke("BecomeWhite", 0.2f);
            if (this.GetComponent<Boss>().HP > 0)
            {
                rb.AddForce(transform.up * 0, ForceMode2D.Impulse);
            }
            else
            {
                int RandomVar;
                RandomVar = Random.Range(100,300);
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

