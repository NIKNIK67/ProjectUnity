using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CameraAnim : MonoBehaviour
{

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
        GameObject.FindGameObjectWithTag("HP").GetComponent<Text>().text = System.Convert.ToString(GameObject.FindGameObjectWithTag("Player").GetComponent<First>().HP);
        if (hited) 
        { 
            anim.SetInteger("s", 0);
            hited = false; 
        }
        else 
        { 
            anim.SetInteger("s", move);
        }
        if (move!=3 || move!=5)
        {
            move = 3;
        }
        

    }
    public void Resume()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<First>().Resume();
    }
    public void Exit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<First>().Resume();
        SceneManager.LoadScene(0) ;


    }
}