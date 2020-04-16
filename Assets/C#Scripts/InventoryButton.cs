using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryButton : MonoBehaviour
{
    int triger = 0;     
    public GameObject stone; 
    public GameObject wood; 
    public GameObject iron;
    public GameObject StoneText;
    public GameObject WoodText;
    public GameObject IronText;
    public void Start()
    {
       
    }
    public void OnClick()
    {

        if (triger % 2 == 0)
        {
            stone.gameObject.SetActive(false);
            wood.gameObject.SetActive(false);
            iron.gameObject.SetActive(false);
           
        }
        if (triger % 2 == 1)
        {
            stone.gameObject.SetActive(true);
            wood.gameObject.SetActive(true);
            iron.gameObject.SetActive(true);
        }
        triger += 1;
        
    }
    public void Update()
    {
        StoneText.GetComponent<Text>().text=System.Convert.ToString( GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Stone);
        WoodText.GetComponent<Text>().text = System.Convert.ToString(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Wood);
        IronText.GetComponent<Text>().text = System.Convert.ToString(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Iron);
    }
}
