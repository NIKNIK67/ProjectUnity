using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Menu_go;
    void Update()
    {
        bool ispause = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ispause;
        Menu_go.gameObject.SetActive(ispause);
        
    }
}
