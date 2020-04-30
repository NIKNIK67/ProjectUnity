using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decription : MonoBehaviour
{
    public GameObject MyDscription;
    bool Active = false;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Active = true;
            MyDscription.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MyDscription.SetActive(false);
            }
    }

}
