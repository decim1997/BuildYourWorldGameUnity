using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harvest : MonoBehaviour
{
    public string lootMats = "";
    public int howmuchloot = 0;
    public string withinRange = "no";
    public Transform particuleffect;
    public int durabilityval = 3;
    public Material crack1;
    public Material crack2;
    public Transform bottomblock;
    public Transform myparticle;

    public InventoryScript inventoryscript;

    private void OnTriggerEnter(Collider other)
    {
        withinRange = "yes";
    }

    private void OnTriggerExit(Collider other)
    {
        withinRange = "no";
    }

    // Start is called before the first frame update
    void Start()
    {
        howmuchloot = Random.Range(0, 20);
        inventoryscript = GameObject.Find("SceneController").GetComponent<InventoryScript>();

        if (gameObject.name == "Tree(Clone)")
        {
            lootMats = "wood";
            Debug.Log("It is a tree");
        }
        if (gameObject.name == "NGrassCube(Clone)")
        {
            lootMats = "cube";
            Debug.Log("It is a cube");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {

        if(BlockScript.buildMode.Equals("on"))
        {
            BlockScript.currentSelectetile = transform.position;
        }

        if (withinRange == "yes" && BlockScript.buildMode.Equals("off"))
        {
            durabilityval -= 1;

            Instantiate(myparticle, transform.position, myparticle.rotation);
            if(durabilityval == 2)
            {
                bottomblock.GetComponent<Renderer>().material = crack1;

            }

            if (durabilityval == 1)
            {
                bottomblock.GetComponent<Renderer>().material = crack2;
            }

            if (durabilityval <1)
            {

                if (BlockScript.invSlot[0] == lootMats)
                {
                    BlockScript.inventoryslotquantity[0] += howmuchloot;
                    //here
                    // inventory.AddItem();
                    if (lootMats.Equals("wood"))
                    {
                        inventoryscript.AddItem(3);
                    }
                    if (lootMats.Equals("cube"))
                    {
                        inventoryscript.AddItem(2);
                    }
                    lootMats = "";
                    howmuchloot = 0;
                }

                if (BlockScript.invSlot[1] == lootMats)
                {
                    BlockScript.inventoryslotquantity[1] += howmuchloot;

                    if (lootMats.Equals("wood"))
                    {
                        inventoryscript.AddItem(3);
                    }
                    if (lootMats.Equals("cube"))
                    {
                        inventoryscript.AddItem(2);                        
                    }
                    lootMats = "";
                    howmuchloot = 0;
                }

                if (BlockScript.invSlot[2] == lootMats)
                {
                    BlockScript.inventoryslotquantity[2] += howmuchloot;

                    if (lootMats.Equals("wood"))
                    {
                        inventoryscript.AddItem(3);
                    }
                    if (lootMats.Equals("cube"))
                    {
                        inventoryscript.AddItem(2);
                    }
                    lootMats = "";
                    howmuchloot = 0;
                }

                if (BlockScript.invSlot[3] == lootMats)
                {
                    BlockScript.inventoryslotquantity[3] += howmuchloot;

                    Debug.Log("we enter here4");
                    if (lootMats.Equals("wood"))
                    {
                        inventoryscript.AddItem(3);
                    }
                    if (lootMats.Equals("cube"))
                    {
                        inventoryscript.AddItem(2);
                    }
                    lootMats = "";
                    howmuchloot = 0;
                }

                if (BlockScript.invSlot[0]=="")
                {
                    BlockScript.invSlot[0] = lootMats;
                    BlockScript.inventoryslotquantity[0] = howmuchloot;
                }

               else
                    if (BlockScript.invSlot[1] == "")
                    {
                    BlockScript.inventoryslotquantity[1] = howmuchloot;
                    BlockScript.invSlot[1] = lootMats;

                    Debug.Log("we enter here");

                }

                else
                    if(BlockScript.invSlot[2]=="")
                    {
                    BlockScript.inventoryslotquantity[2] = howmuchloot;
                    BlockScript.invSlot[2] = lootMats;
                    Debug.Log("we enter here2");
                }

                else 
                if (BlockScript.invSlot[3] == "")
                {
                    BlockScript.inventoryslotquantity[3] = howmuchloot;
                    BlockScript.invSlot[3] = lootMats;
                    Debug.Log("we enter here3");
                }

                Debug.Log(BlockScript.invSlot[0]+" "+ BlockScript.invSlot[1]+" "+ BlockScript.invSlot[2]);
                Debug.Log(BlockScript.inventoryslotquantity[0]+" "+ BlockScript.inventoryslotquantity[1]+" "+ BlockScript.inventoryslotquantity[2]);
                Instantiate(particuleffect, transform.position, particuleffect.rotation);
                Destroy(gameObject);
                if (lootMats.Equals("wood"))
                {
                    inventoryscript.AddItem(3);
                }
                if (lootMats.Equals("cube"))
                {
                    inventoryscript.AddItem(2);
                }

            }

        }
           
    }

}
