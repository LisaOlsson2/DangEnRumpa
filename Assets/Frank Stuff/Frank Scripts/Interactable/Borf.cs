using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Borf : DefaultInteractable
{
    [PunRPC]
    public override void OnInteract()
    {
        print("Borf");
    }
}
