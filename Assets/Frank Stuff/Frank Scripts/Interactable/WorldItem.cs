using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Photon.Pun;

public class WorldItem : DefaultInteractable
{

    int itemIndex;
    [SerializeField]
    bool isTool;

    private void Start()
    {
        transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, 1, transform.parent.transform.position.z);

    }

    public override void OnInteract()
    {

        


        if (isTool)
        {
            for (int i = 0; i < player.GetComponent<PlayerController>().toolList.Length; i++)
            {
                //print(player.GetComponent<PlayerController>().toolList[i]);
                if (player.GetComponent<PlayerController>().toolList[i].name == transform.parent.gameObject.name)
                {
                    itemIndex = i + 1;
                    transform.parent.name = player.GetComponent<PlayerController>().toolList[i].name;
                    //print(itemIndex);
                    break;
                }
            }

            
            if (player.GetComponent<PlayerController>().tool == 0)
            {
                print("Tool Pickup");
                player.GetComponent<PlayerController>().tool = itemIndex;
                if (GetComponentInParent<PhotonView>().IsMine)
                {
                    PhotonNetwork.Destroy(transform.parent.gameObject);
                }
                
            }
            else
            {
                print("Hands Full");
            }
        }
        else
        {
            for (int i = 0; i < player.GetComponent<PlayerController>().itemList.Length; i++)
            {
                //print(player.GetComponent<PlayerController>().itemList[i]);
                if (player.GetComponent<PlayerController>().itemList[i].name == transform.parent.gameObject.name)
                {
                    itemIndex = i + 1;
                    //print(itemIndex);
                    break;
                }
            }

            int[] slot = player.GetComponent<PlayerController>().itemInventory;
            if (slot[player.GetComponent<PlayerController>().selectedItem] == 0)
            {
                print("Item Pickup");
                slot[player.GetComponent<PlayerController>().selectedItem] = itemIndex;
                if (GetComponentInParent<PhotonView>().IsMine)
                {
                    PhotonNetwork.Destroy(transform.parent.gameObject);
                }
                
            }
            else
            {
                print("Slot Full");
            }
        }
        
        
    }
}
