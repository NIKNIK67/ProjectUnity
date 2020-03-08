using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorilaScript : MonoBehaviour
{
    public int i;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(15f, rb.velocity.y);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            rb.transform.position = new Vector2(rb.position.x, rb.position.y);
        }
    }
}
