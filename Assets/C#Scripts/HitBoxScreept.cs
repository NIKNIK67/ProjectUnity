using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxScrept : MonoBehaviour
{
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            i++;
            BoxCollider2D x = gameObject.AddComponent<BoxCollider2D>();
            x.isTrigger = true;
            Invoke("my_Destroy", 0.1f);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            print("Hitted");


        }
        
    }
    void my_Destroy()

    {
        Destroy(gameObject);
    }

}

