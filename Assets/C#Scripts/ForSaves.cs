using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class ForSaves : MonoBehaviour
{
    public data MyData = new data();
    string path;
    void Start()
    {
        path = Path.Combine(Application.dataPath, "Save.json");
        if (File.Exists(path))
        {
            MyData = JsonUtility.FromJson<data>(File.ReadAllText(path));

        }
    }

    public void SaveMyData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(MyData));
    }

}
[Serializable]
public class data
{
    public int coin = 0;
    public int wood = 0;
    public int rock = 0;
    public int iron = 0;
    public float Damage = 1;
    public bool[] levelsOne = new bool[6] { true, false, false, false, false, false };
    public bool[] levelsTwo = new bool[6] { false, false, false, false, false, false };
    public bool[] Skills = new bool[5] { false, false, false, false, false };
}