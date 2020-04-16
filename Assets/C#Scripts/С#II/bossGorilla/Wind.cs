using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    GameObject Player;
    public float WhereToWind;
    bool r;
    float s;
    public float f;
    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        f = Player.transform.rotation.y;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            if (Player.transform.rotation.y == -1)
            {
                s = -WhereToWind;
            }
            else
            {
                s = WhereToWind;
            }
            Player.transform.Translate(Vector2.right * s * Time.deltaTime);
        }
    }
}
