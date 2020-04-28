using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    /*
    public bool CupOfBlood;
    public bool PowerOfSolaris;
    public bool SkeletonRage;
    public bool FrogLegs;
    public bool PumaSpeed;
    */
    public bool[] Skils = { false, false, false, false, false };

    private void Start()
    {
        Skils = GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.Skills;
        if (Skils[0])
        {
            Update1();
        }
        if (Skils[1])
        {
            Update2();
        }
        if (Skils[2])
        {
            Update3();
        }
        if (Skils[3])
        {
            Update4();
        }
        if (Skils[4])
        {
            Update5();

        }
    }
    public void Update1()
    {
        GetComponent<First>().DamageModify[2] = 2;
    }
    public void Update2()
    {
        GetComponent<First>().DashSpeed *= 1.2f;
    }
    public void Update3()
    {
        GetComponent<First>().DamageModify[1] = 1.2f;
        GetComponent<First>().DamageModify[0] = 1.5f;
    }
    public void Update4()
    {
        GetComponent<First>().JumpPower *= 1.1f;
    }
    public void Update5()
    {
        GetComponent<First>().WalkSpeed *= 1.2f;
    }
    public void SendData()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ForSaves>().MyData.Skills = Skils;
    }

}
