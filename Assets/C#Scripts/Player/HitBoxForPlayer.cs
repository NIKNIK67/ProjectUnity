using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxForPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Ds", 0.3f);
    }
    void Ds()
    {
        Destroy(gameObject);
    }
}
