using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : DefaultInteractable
{
    [SerializeField]
    float targetRotation;
    
    float timer;

    bool open = false, canInteract;

    BoxCollider bc;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (open)
        {
            transform.eulerAngles += new Vector3(0, (targetRotation-transform.eulerAngles.y) * 2f, 0)*Time.deltaTime;
        }
        else
        {
            transform.eulerAngles += new Vector3(0, (0 - transform.eulerAngles.y) * 2f, 0)*Time.deltaTime;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            bc.enabled = true;
            canInteract = true;
        }

    }

    public override void OnInteract()
    {
        if (canInteract)
        {
            timer = 0.5f;
            canInteract = false;
            bc.enabled = false;

            if (open)
            {

                open = false;
            }
            else
            {

                open = true;
            }
        }
    }

}
