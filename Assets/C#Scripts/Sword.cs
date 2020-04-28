using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    float AtackReload;
    First a;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AtackReload > -1)
        {
            AtackReload -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q) && AtackReload < 0  && a.UsingLadder!=1)
        {
            AtackReload = 0.3f;
            anim.SetInteger("A", Random.Range(1,4));
        }
        else
        {
            anim.SetInteger("A", 0);
        }
    }
}
