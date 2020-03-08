using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorilaScript : MonoBehaviour
{
    public int i;
    Rigidbody2D rb;
    public int max_x;
    public int min_x;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < max_x && transform.position.x>min_x)
        {
            
            if (Player.transform.position.x > transform.position.x && Player.transform.position.x < max_x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rb.velocity = new Vector2(15f, rb.velocity.y);
            }
            if (Player.transform.position.x < transform.position.x && Player.transform.position.x > min_x)
            {
                transform.eulerAngles = new Vector3(0, 180f, 0);
                rb.velocity = new Vector2(-15f, rb.velocity.y);
            }
        }

       
        if (transform.position.x > max_x)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
            rb.velocity = new Vector2(-15f, rb.velocity.y);
        }
        if (transform.position.x < min_x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(15f, rb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            rb.transform.position = new Vector2(rb.position.x, rb.position.y);
        }
    }
}
