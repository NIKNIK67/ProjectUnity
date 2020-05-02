using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    PlatformEffector2D pl;
    int k = 0;
    public float i = 0;
    void Start()
    {
        pl = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        i -= Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
        {
            i = 0.5f; 
        }
        if (Input.GetKey(KeyCode.Space))
        {
            i = -3f;
        }
        if (i>0 && pl.rotationalOffset != 180f)
        {
            i -= Time.deltaTime;
            pl.rotationalOffset = 180f;
        }
        if  (pl.rotationalOffset!=0f && i <= 0)
        {
            pl.rotationalOffset = 0f;
        }
    }
}
