using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryButton : MonoBehaviour
{
    bool triger = false;     
    public GameObject stone; 
    public GameObject wood; 
    public GameObject iron;
    public GameObject StoneText;
    public GameObject WoodText;
    public GameObject IronText;
    public GameObject Coin;
    public void Start()
    {
       
    }
    public void OnClick()
    {
        while (true)
        {
            if (triger == false)
            {
                wood.SetActive(false);
                iron.SetActive(false);
                stone.SetActive(false);
                triger =true;
                break;
            }
            if (triger)
            {
                wood.SetActive(true);
                iron.SetActive(true);
                stone.SetActive(true);
                triger = false;
                break;
            }
        }
    }
    public void Update()
    {
        Coin.GetComponent<Text>().text = System.Convert.ToString(GameObject.FindGameObjectWithTag("Player").GetComponent<First>().coin);
        StoneText.GetComponent<Text>().text = System.Convert.ToString( GameObject.FindGameObjectWithTag("Player").GetComponent<First>().Stone);
        WoodText.GetComponent<Text>().text = System.Convert.ToString(GameObject.FindGameObjectWithTag("Player").GetComponent<First>().Wood);
        IronText.GetComponent<Text>().text = System.Convert.ToString(GameObject.FindGameObjectWithTag("Player").GetComponent<First>().Iron);
    }
}
