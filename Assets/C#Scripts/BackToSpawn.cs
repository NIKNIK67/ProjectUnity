using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSpawn : MonoBehaviour
{

    public GameObject Spawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<First>().HP -= 1;
            collision.GetComponent<First>().Damage = collision.GetComponent<First>().DefaultDamage * collision.GetComponent<First>().DamageModify[collision.GetComponent<First>().HP - 1];
            collision.transform.position = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            print("Nope");


        }
    }

    }

