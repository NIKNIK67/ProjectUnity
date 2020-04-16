using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            transform.position = new Vector3(Arena.transform.position.x, Arena.transform.position.y,-100);
            camera.orthographicSize = 50;
        }

        else
        {
            camera.orthographicSize = 30;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-100);
        }
       
     }
    public void OnTriggerStay2D(Collider2D col)
    {
        
        
        
      
    }
    public void ExitInMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ispause = false;

    }
}