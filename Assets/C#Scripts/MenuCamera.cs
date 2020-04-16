using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCamera: MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
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
