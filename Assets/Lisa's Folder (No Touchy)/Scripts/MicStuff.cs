using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MicStuff : MonoBehaviour
{
    PhotonView photonView;
    Reference myReference = new();

    [PunRPC]
    void SetSource(Reference reference)
    {
        GetComponent<Rotation>().enabled = true;
        print(reference.audioController);
        //reference.audioController.mineInOthers.Add(GetComponent<AudioSource>());
    }

    void OnEnable()
    {
        ExitGames.Client.Photon.PhotonPeer.RegisterType(typeof(Reference), (byte)'R', Reference.Serialize, Reference.Deserialize);
        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            Destroy(GetComponent<AudioSource>());
            PhotonNetwork.LocalPlayer.TagObject = gameObject;
            myReference.audioController = GetComponent<AudioController>();
        }
        else
        {
            Destroy(GetComponent<AudioController>());
        }
    }
    void Update()
    {
        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Q))
        {
            print(myReference.audioController);
            photonView.RPC("SetSource", RpcTarget.Others, myReference);
        }
    }
}