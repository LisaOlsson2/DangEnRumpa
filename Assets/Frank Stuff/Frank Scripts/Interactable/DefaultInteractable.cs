using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DefaultInteractable : MonoBehaviour
{

    
    [PunRPC]
    public virtual void OnInteract()
    {
        print("Kaboom");
        Destroy(gameObject);
    }
}
