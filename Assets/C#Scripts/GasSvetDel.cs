using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSvetDel : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0);
    }
}
