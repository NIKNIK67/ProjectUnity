using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ccamera : MonoBehaviour
{
    public float max_x, max_Y;
    public GameObject player;
    public GameObject Arena;
    
    void Update()
    {
        Camera camera = GetComponent<Camera>();
        if ((player.transform.position.x > Arena.transform.position.x-100 && player.transform.position.x < Arena.transform.position.x+100)&&(player.transform.position.y < Arena.transform.position.y + 50 && player.transform.position.y > Arena.transform.position.y - 50))
        {
            transform.position = new Vector2(Arena.transform.position.x, Arena.transform.position.y);
            camera.orthographicSize = 50;
        }

        else
        {
            camera.orthographicSize = 30;
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        }
     }
    public void OnTriggerStay2D(Collider2D col)
    {
        
        
        
      
    }
}