using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftingStation : DefaultInteractable
{

    public int[] indexes = new int[5]; 

    [SerializeField]
    GameObject[] slots = new GameObject[5]; //0, 1, 2, tool,output

    [SerializeField]
    GameObject destroyToolIndicator;

    PlayerController pc;

     bool correctTool = false, canCraft = false;
        
    [SerializeField]
    bool destroysTool, toolOutput;

    // Start is called before the first frame update
    void Start()
    {

        pc = FindObjectOfType<PlayerController>();

        if (destroysTool)
        {
            destroyToolIndicator.GetComponent<Image>().color = Color.black;
        }
        else
        {
            destroyToolIndicator.GetComponent<Image>().color = Color.clear;
        }

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<CraftingIcon>().icon = slots[i].transform.GetChild(0).gameObject;
            slots[i].GetComponent<CraftingIcon>().image = slots[i].GetComponent<Image>();
            
            if (indexes[i] == 0)
            {
                slots[i].GetComponent<CraftingIcon>().icon.GetComponent<Image>().color = Color.clear;
                
                slots[i].GetComponent<CraftingIcon>().image.color = Color.white;
            }
            else
            {
                if (i == 3)
                {
                    slots[i].GetComponent<CraftingIcon>().icon.GetComponent<Image>().sprite = pc.toolList[indexes[i] - 1].GetComponentInChildren<SpriteRenderer>().sprite;
                    slots[i].GetComponent<CraftingIcon>().index = indexes[0];
                    slots[i].GetComponent<CraftingIcon>().image.color = Color.magenta;
                }
                else
                {
                    slots[i].GetComponent<CraftingIcon>().icon.GetComponent<Image>().sprite = pc.itemList[indexes[i] - 1].GetComponentInChildren<SpriteRenderer>().sprite;
                    slots[i].GetComponent<CraftingIcon>().index = indexes[0];
                    slots[i].GetComponent<CraftingIcon>().image.color = Color.magenta;
                }
                
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (indexes[i] != 0)
            {
                slots[i].GetComponent<CraftingIcon>().index = indexes[0];
                slots[i].GetComponent<CraftingIcon>().image.color = Color.magenta;
            }

        }

        if (indexes[3] != 0)
        {
            if (pc.tool == indexes[3])
            {
                slots[3].GetComponent<CraftingIcon>().image.color = Color.green;
                correctTool = true;
            }
            else
            {
                correctTool = false;
            }

        }


        List<int> inventoryCheck = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            if (pc.itemInventory[i] == 0)
            {
                inventoryCheck.Add(-1);
            }
            else
            {
                inventoryCheck.Add(pc.itemInventory[i]);
            }
            
        }

        List<int> correctPlacements = new List<int>();
        int materialCount = 0;

        for (int i = 0; i < 3; i++)
        {
            if (indexes[i] != 0)
            {
                materialCount += 1;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int ii = 0; ii < 3; ii++)
            {
                if (indexes[ii] == inventoryCheck[i] && correctPlacements.Count < materialCount)
                {
                    correctPlacements.Add(i);
                    break;
                }
            }
        }

       

        //print("---");
        string array = "";
        foreach (int item in correctPlacements)
        {
            array += item;
        }
        //print(array);

        if (correctPlacements.Count == materialCount && correctTool)
        {
            slots[4].GetComponent<CraftingIcon>().image.color = Color.green;
            canCraft = true;
        }
        else
        {
            slots[4].GetComponent<CraftingIcon>().image.color = Color.magenta;
            canCraft = false;

        }

        List<int> lightUpSigns = new List<int>();

        for (int i = 0; i < correctPlacements.Count; i++)
        {
            for (int ii = 0; ii < 3; ii++)
            {
                if (pc.itemInventory[correctPlacements[i]] == indexes[ii])
                {
                    

                    lightUpSigns.Add(pc.itemInventory[correctPlacements[i]]);
                    
                    break;

                }
            }
            
            
        }

        //print("---");
        array = "";
        foreach (int item in lightUpSigns)
        {
            array += item;
        }
        //print(array);

        for (int i = 0; i < 3; i++)
        {
            for (int ii = 0; ii < lightUpSigns.Count; ii++)
            {
                if (indexes[i] == lightUpSigns[ii])
                {
                    slots[i].GetComponent<CraftingIcon>().image.color = Color.green;
                    lightUpSigns.RemoveAt(ii);
                    break;
                }
            }
            
        }

        /*
        List<int> empties = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            if (indexes[i] > 0)
            {
                for (int i2 = 0; i2 < inventoryCheck.Length; i2++)
                {
                    if (inventoryCheck[i2] == indexes[i])
                    {
                        inventoryCheck[i] = indexes[i];
                        inventoryCheck[i2] = 0;
                    }
                    break;
                }
            }
            else
            {
                empties.Add(i);
            }
        }

        foreach (int i in empties)
        {
            inventoryCheck[i] = 0;
        }

        print("---");
        string array = "";
        foreach (int item in inventoryCheck)
        {
            array += item;
        }
        print(array);

        */


    }

    public override void OnInteract()
    {

        if (canCraft)
        {
            print("Cha-Ching");


            List<int> requiredMaterials = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                requiredMaterials.Add(indexes[i]);
            }

            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    if (true)
                    {
                        if (indexes[i] == requiredMaterials[ii])
                        {
                            pc.itemInventory[i] = 0;
                            requiredMaterials.RemoveAt(ii);
                            break;
                        }
                    }
                }
            }

            if (destroysTool)
            {
                pc.tool = 0;
            }


            GameObject thing = Instantiate(pc.itemList[indexes[4] - 1], transform.position + transform.forward, Quaternion.identity);
            thing.name = pc.itemList[indexes[4] - 1].name; 
        }
        else
        {
            print("Not the required materials");
        }

        

    }
}
