using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemBase : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
}
[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public Sprite image;
}