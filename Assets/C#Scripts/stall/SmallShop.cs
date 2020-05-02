using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SmallShop : MonoBehaviour
{
    public string[] MagicDescription;
    public int[] price = new int[2] { 200, 300 };
    First Player;
    data ForSavesVar;
    bool MayUse;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI DescriptionTextPrice;
    public GameObject Description1;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        ForSavesVar = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData;
    }
    void Update()
    {
        if (MayUse)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!Player.ActiveSkills[0])
                {
                    if (Player.coin >= price[0])
                    {
                        Player.ActiveSkills[0] = true;
                        Player.coin -= price[0];
                        UpdateData();
                    }
                }
                else if (!Player.ActiveSkills[1])
                {
                    if (Player.coin >= price[1])
                    {
                        Player.ActiveSkills[1] = true;
                        Player.coin -= price[1];
                        UpdateData();
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
            UpdateData();
            Description1.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MayUse = false;
            Description1.SetActive(false);
        }
    }
    void UpdateData()
    {
        if (!Player.ActiveSkills[0])
        {
            DescriptionText.text = MagicDescription[0];
            DescriptionTextPrice.text = price[0].ToString();
        }
        else if (!Player.ActiveSkills[1])
        {
            DescriptionText.text = MagicDescription[1];
            DescriptionTextPrice.text = price[1].ToString();
        }
        else
        {
            DescriptionText.text = "I have no more idea what to sell..." +
                "Sorry... another staff are too expensive for you";
            DescriptionTextPrice.text = "My next treasure is priceless";
        }
    }
}

