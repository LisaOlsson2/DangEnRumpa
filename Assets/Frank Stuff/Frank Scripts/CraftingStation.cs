using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftingStation : DefaultInteractable
{

    public int[] indexes = new int[5]; 

    [SerializeField]
    GameObject[] slots = new GameObject[5]; //0, 1, 2, tool,output

    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {

        pc = FindObjectOfType<PlayerController>();

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
                slots[i].GetComponent<CraftingIcon>().icon.GetComponent<Image>().sprite = pc.itemList[indexes[i]-1].GetComponentInChildren<SpriteRenderer>().sprite;
                slots[i].GetComponent<CraftingIcon>().index = indexes[0];
                slots[i].GetComponent<CraftingIcon>().image.color = Color.magenta;
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        int[] inventoryCheck = new int[pc.itemInventory.Length];

        for (int i = 0; i < inventoryCheck.Length; i++)
        {
            inventoryCheck[i] = pc.itemInventory[i];
        }


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

        

        for (int i = 0; i < slots.Length; i++)
        {

            

            if (indexes[i] != 0)
            {
                slots[i].GetComponent<CraftingIcon>().index = indexes[0];
                slots[i].GetComponent<CraftingIcon>().image.color = Color.magenta;
            }
            
        }
    }

    public override void OnInteract()
    {
        print("Cha-Ching");


    }
}
