using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wawe1 : MonoBehaviour
{
    public int direction;
    public float speed;
    public float Maxx, Minx;

    void Update()
    {
        transform.Translate(-Vector2.right * speed * direction * Time.deltaTime);
        
        if(transform.position.x> Maxx || transform.position.x<Minx)
        {
            Destroy(gameObject);
        }
    }
}
