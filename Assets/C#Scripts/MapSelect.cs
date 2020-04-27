using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public int part;
    public bool[] part1 = new bool[6];
    public bool[] part2 = new bool[6];
    private void Start()
    {
        part1= GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsOne;
        part2= GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsTwo;
    }
    public void RunLvl(int number)
    {

        if (part1[number - 3])
        {
            Application.LoadLevel(number);
        }
    }



}
