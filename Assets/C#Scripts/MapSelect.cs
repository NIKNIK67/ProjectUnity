using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public int part;
    public bool[] part1 = new bool[4];
    public bool[] part2 = new bool[4];
    private void Start()
    {
        part1 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsOne;
        part2 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsTwo;
        StartCoroutine(up());
    }
    IEnumerator up()
    {
        yield return new WaitForSeconds(0.1f);
        part1 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsOne;
        part2 = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.levelsTwo;
    }
    public void runlvl(int number)
    {

        if (number<8&&part1[number - 3] == true && part == 0)
        {
     
            Application.LoadLevel(number);
        }

        if (part2[number-8] && part == 1)
        {

            Application.LoadLevel(number);
        }
    }



}
