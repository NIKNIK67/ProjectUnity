using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRandomDirection : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(0f, 10.0f)).normalized * 20, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.layer = 15;
    }
}
