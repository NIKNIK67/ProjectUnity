using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
public class Save :MonoBehaviour
{
    public void save ( )
    { int wood, iron, coin, stone,hp;
        wood = GameObject.FindGameObjectWithTag("Player").GetComponent<First>().Wood;
        iron = GameObject.FindGameObjectWithTag("Player").GetComponent<First>().Iron;
        stone = GameObject.FindGameObjectWithTag("Player").GetComponent<First>().Stone;
        coin = GameObject.FindGameObjectWithTag("Player").GetComponent<First>().coin;
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<First>().HP;
        
    }
    public void load()
    { 
    
    }   
 

}
