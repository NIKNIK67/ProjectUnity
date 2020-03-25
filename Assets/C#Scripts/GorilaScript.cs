using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GorilaScript : MonoBehaviour
{
    public int hp;
    public int i;
    Rigidbody2D rb;
    public int max_x;
    public int min_x;
    public GameObject Player;
    public float time =10;
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
            if (Player.transform.position.x > transform.position.x - 20 && Player.transform.position.x < transform.position.x + 20)
            {
                if (Player.transform.position.x > transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    if (time > 5)
                    {
                        Invoke("atack", 1f);
                        time = 0;
                    }
                }
                if (Player.transform.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180f, 0);
                    if (time > 5)
                    {
                        Invoke("atack", 1f);
                        time = 0;
                    }
                }

            }
            if (Player.transform.position.x < max_x && Player.transform.position.x > min_x)
            {
                if (Player.transform.position.x > transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    rb.velocity = new Vector2(10f, rb.velocity.y);
                }
                if (Player.transform.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180f, 0);
                    rb.velocity = new Vector2(-10f, rb.velocity.y);
                }
            }
         
        }
        time += Time.deltaTime;
        
        
        if (transform.position.x > max_x)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
            rb.velocity = new Vector2(-10f, rb.velocity.y);
        }
        if (transform.position.x < min_x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(10f, rb.velocity.y);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
          

    }
    public void atack()
    {
        if (Player.transform.position.x > transform.position.x - 20 && Player.transform.position.x < transform.position.x + 20)
        {

            Player.GetComponent<First>().hp -= 1;
            
        }
    }

}
