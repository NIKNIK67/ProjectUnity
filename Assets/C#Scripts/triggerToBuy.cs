using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerToBuy : MonoBehaviour
{
    First AllData;
    bool MayIBuyIt = false;
    public int Number; //номер в массиве улучшений
    int PlayerWood;
    int PlayerStone;
    int PlayerIron;
    public int PriceWood;
    public int PriceStone;
    public int PriceIron;


    private void Start()
    {
        AllData = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
    }
    void Update()
    {
        if(MayIBuyIt && Input.GetKeyDown(KeyCode.F))
        {
            UpdateDataAboutMAterials();
            if(PriceWood <= PlayerWood && PriceStone <= PlayerStone && PriceIron <= PlayerIron)
            {
                AllData.Wood -= PriceWood;
                AllData.Stone -= PriceStone;
                AllData.Iron -= PriceIron;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Items>().Skils[Number] = true;
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MayIBuyIt = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MayIBuyIt = false;
        }
    }
    void UpdateDataAboutMAterials()
    {
        PlayerWood = AllData.Wood;
        PlayerStone = AllData.Stone;
        PlayerIron = AllData.Iron;
    }

}
