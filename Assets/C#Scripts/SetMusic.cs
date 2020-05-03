using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetMusic : MonoBehaviour
{
    public AudioClip Music;

    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<AudioSource>().clip = Music;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
