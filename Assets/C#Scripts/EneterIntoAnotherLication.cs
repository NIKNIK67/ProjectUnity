using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EneterIntoAnotherLication : MonoBehaviour
{
    public int NumperOfLocation;
    bool MayUse;
    data ForSavesVar;
    First Player;
    GameObject Dead;
    public GameObject MapCanvas;
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                if( this.tag == "Map")
                {
                    if (gameObject.GetComponent<MapSelect>().part == 0)
                    {
                        MapCanvas.SetActive(true);
                    }
                }
                else
                {
                    StartCoroutine(MYLVL(NumperOfLocation));
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
        if (this.gameObject.tag == "Map")
        {
            MapCanvas.SetActive(false);
        }
    }
    IEnumerator MYLVL(int numb)
    {
        ForSavesVar.coin = Player.coin;
        ForSavesVar.iron = Player.Iron;
        ForSavesVar.wood = Player.Wood;
        ForSavesVar.rock = Player.Stone;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().SaveMyData();
        Dead.SetActive(true);
        yield return new WaitForSeconds(2);
        Application.LoadLevel(numb);
    }
       
}
