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
            collision.transform.position = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
            print("Nope");


        }
    }

    }

