using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetMyDamage : MonoBehaviour
{
    First Player;
    TextMeshProUGUI some;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        some = this.GetComponent<TextMeshProUGUI>();
        UpdateData();
    }

    public void UpdateData()
    {
        some.text ="Your damage is " + Player.DefaultDamage.ToString() + "  now";
    }
}
