using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Item
{
    public int Id;
    public string Name;
    public bool Stackable;
    public bool Placeable;
    public string Slug;
    public int Quantity;
    public Sprite sprite;
    public GameObject myobject;
    
    public Item(int id,string name,bool stackable,bool placeable, string slug,int quantity)
    {
        
        this.Id = id;
        this.Name = name;
        this.Stackable = stackable;
        this.Placeable = placeable;
        this.Slug = slug;
        this.Quantity = quantity;
        sprite = Resources.Load<Sprite>("Sprites/"+slug);
        myobject = Resources.Load<GameObject>("Blocks/"+slug+"Block");
    }
}
public class BlockScript : MonoBehaviour
{
    public List<Item> AllItem = new List<Item>();
    public Transform grassblock;
    public Transform cleyblock;
    public Transform treeblock;
    public static List<string> invSlot = new List<string>() {"","","","","","","","","","","","","","","","","","" };
    public static List<int> inventoryslotquantity = new List<int>() { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    public static Dictionary<string, int> inventory = new Dictionary<string, int>();
    // Start is called before the first frame update
    public Transform slot0Text;
    public Transform slot1Text;
    public Transform slot2Text;
    public Transform slot3Text;


    public Transform slot0QText;
    public Transform slot1QText;
    public Transform slot2QText;
    public Transform slot3QText;

    public Transform cavansobg;

    public KeyCode toogleinventory;

    public string inventorystatus="n";

    public static string selectedRecipe;

    public GameObject pickaxesButton;
    public GameObject showelButton;

    public static string havepickaxesplan = "n";
    public static string haveShowePlan = "n";

    public string hasRequRes1 = "n";
    public string hasReqRes2 = "n";


    public int usedInvSlot1 = 0;
    public int usedInvSlot2 = 0;


    public int reqResQ1 = 0;
    public int reqResQ2 = 0;
    public static string buildMode = "off";

    public static Vector3 currentSelectetile;

    public Transform woodblack;
    public Transform metalblock;
    public GameObject invPanel;
    float itemindex;
    InventoryScript inventoryscript;
    Camera cam;
    float maxrange = 7;

    public Item GetItemById(int id)
    {
        for (int i = 0; i < AllItem.Count; i++)
        {
            if(AllItem[i].Id == id)
            {
                return AllItem[i];
            }
        }

        return AllItem[0];
    }
  public  void GetDatabase(string path)
    {

   
        StreamReader sr = new StreamReader(path);


        AddItem:
        AllItem.Add(new Item(
            int.Parse(sr.ReadLine().Replace("id: ","")),
            sr.ReadLine().Replace("name: ",""),
            bool.Parse(sr.ReadLine().Replace("stackable: ", "")),
            bool.Parse(sr.ReadLine().Replace("placeable: ", "")),
            sr.ReadLine().Replace("slug: ",""),
            int.Parse(sr.ReadLine().Replace("quantity: ", ""))
            ));

        string c = sr.ReadLine();

        if(c == ",")
        {
            goto AddItem;
        }
        else if(c == ";")
        {
            sr.Close();
        }
        else
        {
            Debug.Log("Does not have correct line ending");
        }
    }

    void Start()
    {

        GetDatabase("Assets/Resources/item.txt");
        pickaxesButton.SetActive(false);
        showelButton.SetActive(false);  

        inventoryscript = GameObject.Find("SceneController").GetComponent<InventoryScript>();
        cam = Camera.main;

        Instantiate(treeblock, new Vector3(0, 2.5f, -4), treeblock.rotation);
        Instantiate(treeblock, new Vector3(2, 2.5f, -4), treeblock.rotation);

        for (int xpos=-5; xpos<50; xpos++)
        {
            for(int zpos=-10; zpos<50;zpos++)
            {
                Instantiate(grassblock, new Vector3(xpos, 0, zpos), grassblock.rotation);
                Instantiate(cleyblock, new Vector3(xpos, -1, zpos), cleyblock.rotation);

            }
        }

        for (int xpos = -5; xpos < 50; xpos++)
        {
            for (int zpos = -3; zpos < 40; zpos++)
            {
                Instantiate(grassblock, new Vector3(xpos, 1, zpos), grassblock.rotation);
            }
        }

        for (int xpos = -5; xpos < 50; xpos++)
        {
            for (int zpos = -2; zpos < 30; zpos++)
            {
                Instantiate(grassblock, new Vector3(xpos, 2, zpos), grassblock.rotation);
            }
        }

        for (int xpos = -5; xpos < 50; xpos++)
        {
            for (int zpos = -1; zpos < 20; zpos++)
            {
                Instantiate(grassblock, new Vector3(xpos, 3, zpos), grassblock.rotation);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckKey();
        BuildWithBlock();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (havepickaxesplan.Equals("y"))
        {
            pickaxesButton.SetActive(true);
        }

        if (haveShowePlan.Equals("y"))
        {
            showelButton.SetActive(true);
        }

        if (Input.GetKeyDown(toogleinventory))
        {
            if (inventorystatus.Equals("n"))
            {
                //  cavansobg.GetComponent<Canvas>().enabled = true;
                //inventoryCanvas.GetComponent<Canvas>().enabled = true;
                // inventoryCanvas.GetComponent<Canvas>().enabled = true;
                invPanel.SetActive(true);
                 inventorystatus = "y";
            }
            else
            {
                // cavansobg.GetComponent<Canvas>().enabled = false;
                // inventoryCanvas.GetComponent<Canvas>().enabled = false;
                invPanel.SetActive(false);
                inventorystatus = "n";
            }
        }
        slot0Text.GetComponent<Text>().text = invSlot[0];
        slot1Text.GetComponent<Text>().text = invSlot[1];
        slot2Text.GetComponent<Text>().text = invSlot[2];
        slot3Text.GetComponent<Text>().text = invSlot[3];


        slot0QText.GetComponent<Text>().text = inventoryslotquantity[0].ToString();
        slot1QText.GetComponent<Text>().text = inventoryslotquantity[1].ToString();
        slot2QText.GetComponent<Text>().text = inventoryslotquantity[2].ToString();
        slot3QText.GetComponent<Text>().text = inventoryslotquantity[3].ToString();

        if (Input.GetKeyDown("b"))
        {
            buildMode = "on";
            Debug.Log("we are in buildmode");
        }

        if (Input.GetKeyDown("f"))
        {
            buildMode = "off";
            Debug.Log("buildmode is off");
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(buildMode.Equals("on"))
            {
                Instantiate(woodblack, new Vector3(currentSelectetile.x, currentSelectetile.y + .5f, currentSelectetile.z), woodblack.rotation);
            }
        }
    }

    public void BuildWithBlock()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(inventoryscript.items[inventoryscript.hoverindex].Placeable == true)
            {
                Ray ray = new Ray(cam.transform.position,cam.transform.forward);
                RaycastHit hit;

                buildMode = "on";

                if (Physics.Raycast(ray, out hit, maxrange))
                {


                    Vector3 spawnPos = Vector3.zero;
                        //new Vector3(1.517f, 0.58f, -6.63f);
                        //Vector3.zero;

                    float xDiff = hit.point.x - hit.transform.position.x;
                    float yDiff = hit.point.y - hit.transform.position.y;
                    float zDiff = hit.point.z - hit.transform.position.z;

                    Debug.Log("xdiff: "+ Mathf.Abs(xDiff));
                    Debug.Log("ydiff: "+ Mathf.Abs(yDiff));
                    Debug.Log("zdiff: "+ Mathf.Abs(zDiff));

                    if (Mathf.Abs(yDiff) == 0.5f)
                    {
                        spawnPos = hit.transform.position + (Vector3.up * yDiff) * 2;
                        Debug.Log("first case");
                    }
                    else if (Mathf.Abs(xDiff) == 0.5f)
                    {
                        spawnPos = hit.transform.position + (Vector3.right * xDiff) * 2;
                        Debug.Log("second case");
                    }

                    else if (Mathf.Abs(zDiff) == 0.5f)
                    {
                        spawnPos = hit.transform.position + (Vector3.forward * zDiff) * 2;
                        Debug.Log("third case");
                    }

                    
                    
                    Instantiate(inventoryscript.items[inventoryscript.hoverindex].myobject,new Vector3(currentSelectetile.x, currentSelectetile.y + .5f, currentSelectetile.z), inventoryscript.items[inventoryscript.hoverindex].myobject.transform.rotation);
                    // Instantiate(inventoryscript.items[inventoryscript.hoverindex].myobject,spawnPos, Quaternion.identity);

                    // Instantiate(inventoryscript.items[inventoryscript.hoverindex].myobject, new Vector3(5, 4, 5), Quaternion.identity);
                    // Instantiate(woodblack, new Vector3(currentSelectetile.x, currentSelectetile.y + .5f, currentSelectetile.z), woodblack.rotation);

                    //Instantiate(grassblock, new Vector3(5, 4, 5), grassblock.rotation);

                    inventoryscript.RemoveItem();
                }


            }
            
        }
    }
    public void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemindex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemindex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            itemindex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            itemindex = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            itemindex = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            itemindex = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            itemindex = 6;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            itemindex = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            itemindex = 8;
        }

        //Mouse ScrollWheel
        //Mouse ScrollWheel
        itemindex -= Input.GetAxis("Mouse ScrollWheel") * 5;


        if(itemindex < 0)
        {
            itemindex = 8;
        }
        else if(itemindex > 8)
        {
            itemindex = 0;
        }

        inventoryscript.hoverindex = (int)itemindex;
    }

    public void clickcreateButton()
    {

        if (hasRequRes1.Equals("y") && hasReqRes2.Equals("y"))
        {
            hasRequRes1 = "n";
            hasReqRes2 = "n";

            inventoryslotquantity[usedInvSlot1] -= reqResQ1;
            inventoryslotquantity[usedInvSlot2] -= reqResQ2;

            if (BlockScript.invSlot[0] == "")
            {
                BlockScript.invSlot[0] = selectedRecipe;
                BlockScript.inventoryslotquantity[0] = 1;
            }

            else
                   if (BlockScript.invSlot[1] == "")
            {
                BlockScript.inventoryslotquantity[1] = 1;

                BlockScript.invSlot[1] = selectedRecipe;
            }

            else
                   if (BlockScript.invSlot[2] == "")
            {
                BlockScript.inventoryslotquantity[2] = 1;

                BlockScript.invSlot[2] = selectedRecipe;
            }

            else
               if (BlockScript.invSlot[3] == "")
            {
                BlockScript.inventoryslotquantity[3] = 1;

                BlockScript.invSlot[3] = selectedRecipe;
            }
        }

    }

    public void clickPickAxesRecipe()
    {


        if (!invSlot[0].Equals(null))
        {
            if (invSlot[0].Equals("cube") && inventoryslotquantity[0] > 1)
            {
                hasRequRes1 = "y";
                usedInvSlot1 = 0;
            }

            if (invSlot[0].Equals("wood") && inventoryslotquantity[0] > 1)
            {
                hasReqRes2 = "y";
                usedInvSlot2 = 0;
            }
        }

        if(!invSlot[1].Equals(null))
        {
            if (invSlot[1].Equals("cube") && inventoryslotquantity[1] > 1)
            {
                hasRequRes1 = "y";
                usedInvSlot1 = 1;
            }



            if (invSlot[1].Equals("wood") && inventoryslotquantity[1] > 1)
            {
                hasReqRes2 = "y";
                usedInvSlot2 = 1;
            }
        }




        if (hasRequRes1.Equals("y") && hasReqRes2.Equals("y"))
        {
            selectedRecipe = "Pickaxe";
            reqResQ1 = 2;
            reqResQ2 = 2;
        }


    }


    public void clickShowRecipe()
    {
        selectedRecipe = "Shovel";
    }



}
