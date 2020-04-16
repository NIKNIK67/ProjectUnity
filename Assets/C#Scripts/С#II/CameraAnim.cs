using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    public float max_x, max_Y, t;
    public int move = 5;
    public bool hited;
    private Camera cam;
    public GameObject player;
    Animator anim;
    private void Start()
    {
    anim = GetComponent<Animator>();

    }
    void Update()
    {
        if (hited) { anim.SetInteger("s", 0);  hited = false; }
        else { anim.SetInteger("s", move); }
        if (move!=3 || move!=5)
        {
            move = 3;
        }
        
    }
}