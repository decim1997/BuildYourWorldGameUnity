using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour,IDropHandler
{
    InventoryScript inv;
    public int slotNumber;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("SceneController").GetComponent<InventoryScript>();

    }

    // Update is called once per frame
    void Update()
    {
        itemName = inv.items[slotNumber].Name;
    }

    public void OnDrop(PointerEventData eventData)
    {
        itemDataScript droppedItem = eventData.pointerDrag.GetComponent<itemDataScript>();
        if(inv.items[slotNumber].Id == -1)
        {
            inv.items[droppedItem.curSlot] = inv.database.GetItemById(-1);
            inv.items[slotNumber] = droppedItem.item;
            droppedItem.curSlot = slotNumber;
        }
        else if(droppedItem.curSlot != slotNumber)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<itemDataScript>().curSlot = droppedItem.curSlot;
            item.transform.SetParent(inv.slots[droppedItem.curSlot].transform);
            item.transform.position = inv.slots[droppedItem.curSlot].transform.position;
            inv.items[droppedItem.curSlot] = item.GetComponent<itemDataScript>().item;
            inv.items[slotNumber] = droppedItem.item;
            droppedItem.curSlot = slotNumber;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;
        } 
    }
}
