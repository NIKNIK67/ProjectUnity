using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaTriger : MonoBehaviour
{
    public GorilaII MG;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ! MG.Atacking)
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
