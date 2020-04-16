using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBullets : MonoBehaviour
{
    public float speed;
    GameObject player;
    Vector2 PP;//playerPosition
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PP = new Vector2(player.transform.position.x, player.transform.position.y);
        PP.x +=(PP.x - transform.position.x)*5;
        PP.y +=(PP.y - transform.position.y)*5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PP, speed * Time.deltaTime);
        if (transform.position.x == PP.x && transform.position.y == PP.y)
        {
            Destroy(gameObject);
        }
    }
}
