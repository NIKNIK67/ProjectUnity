using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkayTrigger : MonoBehaviour
{
    public MonkayJ MG;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !MG.Atacking && MG.t2<0)
        {
            MG.MayAtack = true;
            MG.SA = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MG.MayAtack = false;
        }
    }
}
