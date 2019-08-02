using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemDataScript : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    InventoryScript inv;
    public Item item;
    public int amount;
    public int curSlot;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("SceneController").GetComponent<InventoryScript>();
        this.transform.position = inv.slots[curSlot].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData enventdata)
    {
        if(item.Id != -1)
        {
            this.transform.SetParent(this.transform.parent.parent.parent);
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
            this.transform.position = enventdata.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
     if(item.Id != -1)
        {
            transform.SetParent(inv.slots[curSlot].transform);
           // this.transform.position = inv.slots[curSlot].transform.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inv.slots[curSlot].transform);
        this.transform.position = inv.slots[curSlot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
