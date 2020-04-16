using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleBacground : MonoBehaviour
{
    public float max_x, max_Y;
    public GameObject BilletPref;
    void Start()
    {
        SpawnParticleSystem();
    }
    public void SpawnParticleSystem()
    {
        ParticleSystem particleSystem = Instantiate(BilletPref).GetComponent<ParticleSystem>();
        particleSystem.Play();
        StartCoroutine(StopParticleSystem(particleSystem, 1));
    }

    IEnumerator StopParticleSystem(ParticleSystem particleSystem, float time)
    {
        yield return new WaitForSeconds(time);
        particleSystem.Stop();
    }
}
