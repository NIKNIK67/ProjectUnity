using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BoxCollider2D>() == false) 
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
        if (gameObject.GetComponent<Rigidbody2D>() == false)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {   if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<First>().coin += 1;
            Destroy(gameObject);
        }
    }
}
