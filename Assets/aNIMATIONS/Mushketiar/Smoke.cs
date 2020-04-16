using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public float t = 3f;
    public float d = 180;
    void Start()
    {

        transform.eulerAngles = new Vector2(0, d);
        
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
