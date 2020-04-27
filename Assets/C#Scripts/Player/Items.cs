using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public bool CupOfBlood;
    public bool PowerOfSolaris;
    public bool SkeletonRage;
    public bool FrogLegs;
    public bool PumaSpeed;
    private void Start()
    {
        //добавить сейвы
        if (PowerOfSolaris)
        {
              GetComponent<First>().DashSpeed*=1.2f;
        }
    }

}
