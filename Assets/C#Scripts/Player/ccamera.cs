using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ccamera : MonoBehaviour
{
    public float max_x, max_Y, Min_x, Min_y;
    public int move = 5;
    private Camera cam;
    public GameObject player;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
       if ((player.transform.position.x < max_x) && (player.transform.position.x > Min_x))
       {
            transform.position = Vector2.Lerp(transform.position, new Vector2(player.transform.position.x, transform.position.y), 0.1f);
       }
       else
        {
            if (player.transform.position.x > max_x)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(max_x, transform.position.y), 0.1f);
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(Min_x, transform.position.y), 0.1f);
            }
        }
        if ((player.transform.position.y < max_Y) && (player.transform.position.y > Min_y))
       {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, player.transform.position.y), 0.1f);
       }
       else
       {
            if (player.transform.position.y > max_Y)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, max_Y), 0.1f);
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, Min_y), 0.1f);
            }
       }
    }
}