using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetHowMuchItCost : MonoBehaviour
{
    data ForSavesVar;
    First Player;
    TextMeshProUGUI some;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        ForSavesVar = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData;
        some = this.GetComponent<TextMeshProUGUI>();
        UpdateData();
    }
    public void UpdateData()
    {
                if (Player.DefaultDamage != 2)
                {
            int price = 0;
            float k = Player.DefaultDamage;
                        while (k != 1)
                        {
                            k -= 0.1f;
                            price += 20;

                        }
            price += 20;
            some.text = price.ToString() ;
        }
    }
}

