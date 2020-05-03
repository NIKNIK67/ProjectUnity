using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MenuCamera: MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().loop=true;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void newGameLoad(int level)
    {
        SceneManager.LoadScene(level) ;
    }
    public void Exit()
    {
        Application.Quit(0);
    }
}
