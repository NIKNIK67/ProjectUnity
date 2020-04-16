using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAwe3V2 : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 4000);
        }
    }
}
