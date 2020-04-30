using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLoader : MonoBehaviour
{
    public GameObject[] Lvls= new GameObject[6];
    bool[] part1 = new bool[6];
    bool[] part2 = new bool[6];
    public Sprite Can;
    public Sprite Can_t;
    public Sprite Boss;
    private void Start()
    {
        part1 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsOne;
        part2 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsTwo;
        StartCoroutine(up());
        for (int i = 0; i < 5; i++)
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
        if (part1[5]!=true)
        {
            Lvls[5].GetComponent<Image>().sprite = Boss;
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
