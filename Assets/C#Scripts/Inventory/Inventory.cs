using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ItemBase data;
    public List<Iteminventory> items = new List<Iteminventory>();
    public GameObject gameObjectShow;
    public GameObject InventoryMainObject;
    public int Maxcount;
    public Camera cam;
    public EventSystem es;
    public int currentID;
    public Iteminventory currentitem;
    public RectTransform movingObject;
    public Vector3 offset;
    public void Start()
    {
        if (items.Count == 0)
        {
            AddGraphics();
        }
        for (int i = 0; i < Maxcount; i++)
        {
            AddItem(i,data.Items[Random.Range(0,data.Items.Count)],Random.Range(1,99));
        }
        UpdateInventory();
    }
    public void Update()
    {

        if (currentID != -1)
        {
            MoveObject();
        }
    }
    public void AddItem(int id,Item item,int count)
    {
        items[id].id = item.id; 
        items[id].count =count; 
        items[id].itemObject.GetComponent<Image>().sprite =item.image;
        if (count > 1 && item.id != 0)
        {
            items[id].itemObject.GetComponentInChildren<Text>().text = count.ToString();
        }
        else 
        {
            items[id].itemObject.GetComponentInChildren<Text>().text = "";
        }
    }
    public void AddInventoryItem(int id, Iteminventory invItem, int count)
    {
        items[id].id = invItem .id;
        items[id].count = invItem.count;
        items[id].itemObject.GetComponent<Image>().sprite = data.Items[invItem.id].image;
        if (invItem.count > 1 && invItem.id != 0)
        {
            items[id].itemObject.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            items[id].itemObject.GetComponentInChildren<Text>().text = "";
        }
    }
    public void SelectObject()
    {
        if (currentID == -1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentitem = CopyInventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.Items[currentitem.id].image;
            AddItem(currentID, data.Items[0],0);
        }
        else
        {
            AddInventoryItem(currentID, items[int.Parse(es.currentSelectedGameObject.name)],items.Count);
            AddInventoryItem(int.Parse(es.currentSelectedGameObject.name),currentitem, items.Count);
            currentID = -1;
            movingObject.gameObject.SetActive(false);

        }
    }
    public void UpdateInventory()
    {
        for (int i=0; i < Maxcount;  i++)
        {
            if (items[i].id != 0 && items.Count > 1)
            {
                items[i].itemObject.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemObject.GetComponentInChildren<Text>().text = ""; 
            }
            items[i].itemObject.GetComponent<Image>().sprite = data.Items[items[i].id].image;
        }
    }
    public Iteminventory CopyInventoryItem(Iteminventory old)
    {
        Iteminventory New = new Iteminventory();
        New.id = old.id;
        New.itemObject = old.itemObject;
        New.count = old.count;
        return New; 
    }
    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }
    public void AddGraphics()
    {
        for (int i = 0; i < Maxcount; i++)
        {
            GameObject newitem = Instantiate(gameObjectShow,InventoryMainObject.transform) as GameObject;
            newitem.name = i.ToString();
            Iteminventory ii = new Iteminventory();
            ii.itemObject = newitem;
            RectTransform rt = newitem.GetComponent<RectTransform>();
            rt.position = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newitem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
            Button tempButton = newitem.GetComponent<Button>();
            items.Add(ii);
            tempButton.onClick.AddListener(delegate { SelectObject(); });

        }
    }
}
[System.Serializable]
public class Iteminventory
{
    public int id;
    public GameObject itemObject;
    public int count;
}