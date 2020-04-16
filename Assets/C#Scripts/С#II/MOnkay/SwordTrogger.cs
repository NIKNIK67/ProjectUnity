using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrogger : MonoBehaviour
{
    public MonkayJ MG;
    private void Update()
    {
        if (MG.Atacking == true)
        {
            transform.gameObject.tag = "Bullet";
        }
        else
        {
            transform.gameObject.tag = "Untagged";
        }
    }
}

