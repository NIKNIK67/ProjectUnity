using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int id;
    string name;
    void Create(int m_id, string m_name)
    {
        id = m_id;
        name = m_name;
    }
    
    
}
