using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graz : MonoBehaviour
{
    public float t = 3f;
    public float y = 180;
    public float x = -90;
    void Start()
    { 
        transform.eulerAngles = new Vector2(x, y);
    }

    void Update()
    {
        t -= Time.deltaTime;
        if (t < 0)
        {
            Destroy(gameObject);
        }
    }
}

