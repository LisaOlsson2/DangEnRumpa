using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    int slot;

    [SerializeField]
    bool isIcon, isTool;

    PlayerController pc;

    Image image;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<GameSetup>().localPlayer.GetComponent<PlayerController>();

        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTool)
        {
            if (isIcon)
            {
                if (pc.tool != 0)
                {

                    image.sprite = pc.toolList[pc.tool - 1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
                    image.color = Color.white;
                }
                else
                {
                    image.sprite = null;
                    image.color = Color.clear;
                }
            }
            else
            {
                image.color = Color.magenta;
                image.sprite = null;
            }
            
            
        }
        else
        {
            if (isIcon)
            {
                if (pc.itemInventory[slot] != 0)
                {

                    image.sprite = pc.itemList[pc.itemInventory[slot] - 1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
                    image.color = Color.white;
                }
                else
                {
                    image.sprite = null;
                    image.color = Color.clear;
                }
            }
            else
            {
                if (pc.selectedItem == slot)
                {
                    image.color = Color.green;
                }
                else
                {
                    image.color = Color.magenta;
                }
            }
        }
        
    }
}
