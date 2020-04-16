using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bULLETfaLL : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject B;
    GameObject a;
    First pl;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("AF",0.7f);
        a = GameObject.FindGameObjectWithTag("Player");
        pl = a.GetComponent<First>();
    }
    void AF()
    {
        rb.AddForce(Vector2.up * -50);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        { 
            Instantiate(B, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.CompareTag("Player"))
            {
                pl.CCamera.hited = true;
                pl.HP -= 1;
            }
        }
    }
}
