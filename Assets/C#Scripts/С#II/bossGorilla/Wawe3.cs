using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wawe3 : MonoBehaviour
{
    public GameObject WhatToCreate;
    public float Direction;
    void Start()
    {
       Invoke("CreateCopy", 0.15f);
    }
    void CreateCopy()
    {
       if (transform.position.x > -75 && transform.position.x < 149)
       {
            Instantiate(WhatToCreate, new Vector3(transform.position.x + Direction, transform.position.y, transform.position.z),transform.rotation) ;
        }
    }
}
