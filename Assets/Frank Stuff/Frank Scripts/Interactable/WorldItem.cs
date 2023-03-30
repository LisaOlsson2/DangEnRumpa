using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Photon.Pun;

public class WorldItem : DefaultInteractable
{

    public int itemIndex;
    [SerializeField]
    public bool isTool;

    private void Start()
    {
        transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, 1, transform.parent.transform.position.z);

    }
    [PunRPC]
    public override void OnInteract()
    {

        PhotonView.Destroy(transform.parent.gameObject);
        /*
        
        
        */
    }
}
