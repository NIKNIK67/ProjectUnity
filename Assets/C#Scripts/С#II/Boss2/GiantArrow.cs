using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantArrow : MonoBehaviour
{
    public float P1;
    public float P2;
    public float test;
    void Start()
    {
        StartCoroutine(TiPoint());
    }
    void Update()
    {
        test = transform.position.y - P1;

    }
    IEnumerator TiPoint()
    {
        float t = 4;
        while (t>0)
        {
            yield return new WaitForEndOfFrame();
            t -= Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, P1), Time.deltaTime * 0.5f);
        }
        StartCoroutine(T2Point());
    }
    IEnumerator T2Point()
    {
        float t = 1;
        tag = "Bullet";
        while (t > 0)
        {
            t -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, P2), Time.deltaTime * 7f);
        }
        tag = "Untagged";
        StartCoroutine(T3Point());
    }
    IEnumerator T3Point()
    {
        float t = 3;
        while (t>0)
        {
            t -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, 100.9f), Time.deltaTime);
        }
        Destroy(this);
    }
}
