using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLoader : MonoBehaviour
{
    public GameObject MapImage;
    public GameObject[] Lvls= new GameObject[4];
    bool[] part1 = new bool[4];
    bool[] part2 = new bool[4];
    public Sprite Can;
    public Sprite Can_t;
    public Sprite Boss;
    private void Start()
    {
        part1 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsOne;
        part2 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsTwo;
        part1[0] = true;
        StartCoroutine(up());
        if (MapImage.GetComponent<MapSelect>().part == 0)
        { 
            for (int i = 0; i < 3; i++)
            {
                if (part1[i])
                {
                    Lvls[i].GetComponent<Image>().sprite = Can;
                }
                else
                {
                    Lvls[i].GetComponent<Image>().sprite = Can_t;
                }
            }
            if (part1[3]!=true)
            {
                Lvls[3].GetComponent<Image>().sprite = Boss;
            }
        }
        if (MapImage.GetComponent<MapSelect>().part == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                if (part2[i])
                {
                    Lvls[i].GetComponent<Image>().sprite = Can;
                }
                else
                {
                    Lvls[i].GetComponent<Image>().sprite = Can_t;
                }
            }
            if (part2[3] != true)
            {
                Lvls[3].GetComponent<Image>().sprite = Boss;
            }
        }
    }
    IEnumerator up()
    {
        yield return new WaitForSeconds(0.1f);
        part1 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsOne;
        part2 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsTwo;
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    
    }
}
