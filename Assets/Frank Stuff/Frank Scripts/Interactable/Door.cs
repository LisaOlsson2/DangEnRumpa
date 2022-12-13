using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : DefaultInteractable
{

    float targetRotation, rotSpeed = 250, damping = 10;

    bool open = false;

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, (targetRotation+transform.eulerAngles.y)/2, 0);

    }

    public override void OnInteract()
    {
        if (open)
        {
            targetRotation = 0;
            open = false;
        }
        else
        {
            targetRotation = 90;
            open = true;
        }
    }

}
