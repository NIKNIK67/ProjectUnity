using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koval : MonoBehaviour
{
    public int NumperOfLocation;
    public GetMyDamage text;
    public GetHowMuchItCost text2;
    public int price;
    bool MayUse;
    data ForSavesVar;
    First Player;
    GameObject Dead;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        Dead = Player.Dead;
        ForSavesVar = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData;
    }
    void Update()
    {
        if (MayUse)
        {
            text.UpdateData();
            text2.UpdateData();
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Player.DefaultDamage != 2)
                {
                    if (((Player.DefaultDamage - 0.9f) * 200)-0.01 <= Player.coin)
                    {
                        print((Player.DefaultDamage - 1f) * 200);
                        Player.DefaultDamage += 0.1f;
                        text.UpdateData();
                        text2.UpdateData();
                        float k = Player.DefaultDamage;
                        while (k != 1)
                        {
                            k -= 0.1f;
                            Player.coin -= 20;
                        }
                    }
                    else
                    {
                        print((Player.DefaultDamage - 0.9f) * 200);
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MayUse = true;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MayUse = false;
        }
    }
}
