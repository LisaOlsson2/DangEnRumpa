using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Door : DefaultInteractable
{
    [SerializeField]
    float targetRotation;
    
    float timer;

    Material opened, closed;

    public bool open = false, canInteract = true;

    BoxCollider bc;

    

    private void Start()
    {
        bc = GetComponent<BoxCollider>();

        
    }

    private void Update()
    {
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            //bc.enabled = true;
            canInteract = true;
        }

    }
    [PunRPC]
    public override void OnInteract()
    {


        print("interated with door");

        if (canInteract)
        {
            

            timer = 0.5f;
            canInteract = false;
            //bc.enabled = false;

            if (open)
            {
                bc.isTrigger = false;
                GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                open = false;
            }
            else
            {
                bc.isTrigger = true;
                GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                open = true;
            }
        }
    }

}
