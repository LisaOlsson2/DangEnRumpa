using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : DefaultInteractable
{

    int itemIndex;

    private void Start()
    {
        transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, 1, transform.parent.transform.position.z);
    }

    public override void OnInteract()
    {
        for (int i = 0; i< player.GetComponent<PlayerController>().itemList.Length; i++)
        {
            print(player.GetComponent<PlayerController>().itemList[i]);
            if (player.GetComponent<PlayerController>().itemList[i].name == transform.parent.gameObject.name)
            {
                itemIndex = i+1;
                print(itemIndex);
                break;
            }
        }


        int[] slot = player.GetComponent<PlayerController>().itemInventory;
        if (slot[player.GetComponent<PlayerController>().selectedItem] == 0)
        {
            print("Item Pickup");
            slot[player.GetComponent<PlayerController>().selectedItem] = itemIndex;
            Destroy(transform.parent.gameObject);
        }
        else
        {
            print("Slot Full");
        }
        
    }
}
