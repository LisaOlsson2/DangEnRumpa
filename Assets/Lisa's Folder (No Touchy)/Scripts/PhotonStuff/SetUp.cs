using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SetUp : MonoBehaviourPunCallbacks
{
    // remember to enable the rotation 


    Reference myReference = new();

    [PunRPC]
    void SetSource(Reference reference)
    {
        print(reference.audioController);
        //reference.audioController.mineInOthers.Add(GetComponent<AudioSource>());
    }
    
    [PunRPC]
    void SetSource2(Reference reference)
    {
        print(reference.audioSource);
        //GetComponent<AudioController>().mineInOthers.Add(reference.audioSource);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

    }

    public override void OnEnable()
    {

        base.OnEnable();
        ExitGames.Client.Photon.PhotonPeer.RegisterType(typeof(Reference), (byte)'R', Reference.Serialize, Reference.Deserialize);

        if (photonView.IsMine)
        {
            PhotonNetwork.LocalPlayer.TagObject = gameObject;
            Destroy(GetComponent<Rotation>());
            Destroy(GetComponent<Darkness>());

            Destroy(GetComponent<AudioSource>());
            myReference.audioController = GetComponent<AudioController>();
        }
        else
        {
            Destroy(GetComponent<TempPlayerMovement>());
            GetComponent<Darkness>().SetSprite();

            Destroy(GetComponent<AudioController>());
            myReference.audioSource = GetComponent<AudioSource>();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (photonView.IsMine)
            {
                photonView.RPC("SetSource", RpcTarget.Others, myReference); //this is supposed to be called on enable and when another player enters and has chosen their character, targeted at that player
            }
            else
            {
                photonView.RPC("SetSource2", photonView.Owner, myReference);
            }
        }
    }
}