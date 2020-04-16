using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listocki : MonoBehaviour
{
    public ParticleSystem ps;
    public Wind wind;
    AnimationCurve curve = new AnimationCurve();
    void Start()
    {
        StartCoroutine(ToLeft());
        StartCoroutine(A());
    }
    IEnumerator A()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            FLTR();
            StartCoroutine(ToLeft());
            yield return new WaitForSeconds(15);
            StartCoroutine(ToRight());
            FRTL();
        }
    }
    IEnumerator ToLeft() 
    {
        while(wind.WhereToWind > -16)
        {
            wind.WhereToWind -= 1;
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator ToRight()
    {
        while (wind.WhereToWind < 16)
        {
            wind.WhereToWind += 1;
            yield return new WaitForSeconds(0.2f);
        }
    }
    void FLTR()
    {
        Debug.Log("Suka");
        ps = GetComponent<ParticleSystem>();
        var fo = ps.forceOverLifetime;
        fo.enabled = true;

        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(1f, 1f);
        fo.x = new ParticleSystem.MinMaxCurve(2800, curve);
    }
    void FRTL()
    {
        Debug.Log("Blat");
        ps = GetComponent<ParticleSystem>();
        var fo = ps.forceOverLifetime;
        fo.enabled = true;

        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(1f, 1f);
        fo.x = new ParticleSystem.MinMaxCurve(-2800, curve);
    }
}
