using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public BlockScript database;
    public int numberofslot = 9;
    public int slotstorageamount = 36;

    public GameObject slot;
    public GameObject HotBarPannel;
    public GameObject inventoryPannel;
    public List<GameObject> slots = new List<GameObject>();
    public List<Item> items = new List<Item>();
    public GameObject invItem;
    public int hoverindex=0;


    // Start is called before the first frame update
    void Start()
    {
        database = gameObject.GetComponent<BlockScript>();

        for(int i=0;i<numberofslot;i++)
        {
            items.Add(database.GetItemById(-1));
            slots.Add(Instantiate(slot));
            slots[i].GetComponent<SlotScript>().slotNumber = i;
            slots[i].transform.SetParent(HotBarPannel.transform);
            slots[i].GetComponent<RectTransform>().transform.localScale = Vector3.one;
        }

        for (int i = numberofslot; i <slotstorageamount; i++)
        {
            items.Add(database.GetItemById(-1));
            slots.Add(Instantiate(slot));
            slots[i].GetComponent<SlotScript>().slotNumber = i;
            slots[i].transform.SetParent(inventoryPannel.transform);
            slots[i].GetComponent<RectTransform>().transform.localScale = Vector3.one;
        }

       /* AddItem(0);
        AddItem(1);
        AddItem(0);
        AddItem(1);
        AddItem(0);
        AddItem(1);*/
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.GetItemById(id);

        if (itemToAdd.Stackable && CheckInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].Id == id)
                {
                    itemDataScript data = slots[i].transform.GetChild(0).GetComponent<itemDataScript>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].Id == -1)
                {
                   
                    GameObject itemObj = Instantiate(invItem);
                    Debug.Log("Image: " + itemObj.GetComponent<Image>());
                    items[i] = itemToAdd;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.name = itemToAdd.Name;
                    itemObj.transform.localScale = Vector3.one;
                    //  itemObj.GetComponent<Image>().color = Color.red;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                    itemObj.GetComponent<itemDataScript>().curSlot = i;
                    
                    break;
                }
            }
        }
    }

    bool CheckInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].Id == item.Id)
            {
                return true;
            }
        }

        return false;
    }

    public void ToggleInventory()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberofslot; i++)
        {
            if(i == hoverindex)
            {
                slots[i].GetComponent<Image>().color = Color.white;

                Debug.Log("Couleur: "+ slots[i].GetComponent<Image>().color);
            }
            else
            {
                slots[i].GetComponent<Image>().color = slot.GetComponent<Image>().color;
                Debug.Log("Couleur2: " + slot.GetComponent<Image>().color);
            }
        }
    }

    public void RemoveItem()
    {
        for (int i = 0; i < numberofslot; i++)
        {
            if(i == hoverindex && items[i].Id != -1)
            {
                itemDataScript data = slots[i].transform.GetChild(0).GetComponent<itemDataScript>();
                data.amount --;
                if(data.amount <= 0)
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);
                    items[i] = database.GetItemById(-1);
                }
                data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                break;
            }
        }
    }
}
