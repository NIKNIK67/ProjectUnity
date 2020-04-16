using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float t = 4f;
    void Update()
    {
        t -= Time.deltaTime;
        if (t < 0)
        {
            Destroy(gameObject);
        }
    }
}
