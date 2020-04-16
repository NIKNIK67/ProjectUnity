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
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Invoke("my_Destroy", 0.1f);

        }
    }
  public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            
        {
            if (collision.GetComponent<GorilaScript>().hp <= 0)
            {
                GameObject coin = GameObject.CreatePrimitive(PrimitiveType.Cube);
               
                BoxCollider e = coin.GetComponent<BoxCollider>();

                Destroy(e);

                coin.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 1);

                Destroy(collision.gameObject);
                coin.AddComponent<BoxCollider2D>();
                coin.AddComponent<Rigidbody2D>();
                coin.AddComponent<CoinScript>();
                BoxCollider2D box_coin = coin.GetComponent<BoxCollider2D>();


                print("Hitted");

            }
            else
            {
                collision.GetComponent<GorilaScript>().hp -= 1;
            }
        }
    }

    public void my_Destroy()
    {
        Destroy(gameObject);
    }
}

