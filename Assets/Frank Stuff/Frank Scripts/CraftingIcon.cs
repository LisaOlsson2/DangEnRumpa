using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingIcon : MonoBehaviour
{
    
    public int slot, index;

    [SerializeField]
    bool isIcon, isTool, isOutput;

    PlayerController pc;
    CraftingStation station;

    public GameObject icon;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {


        pc = FindObjectOfType<GameSetup>().localPlayer.GetComponent<PlayerController>();



    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isTool)
        {
            if (isIcon)
            {
                if (index != 0)
                {

                    image.sprite = pc.toolList[index - 1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
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
        else if (isOutput)
        {
            if (isIcon)
            {

            }
        }
        else
        { 
            
            
            if (pc.selectedItem == slot)
            {
                image.color = Color.white;
            }
            else
            {
                image.color = Color.magenta;
            }
            
        }
        */

    }
}
