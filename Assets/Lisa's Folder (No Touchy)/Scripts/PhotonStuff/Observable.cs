using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Observable : MonoBehaviourPunCallbacks, IPunObservable
{
    Reference myReference = new Reference();
    AudioController audioController;

    public override void OnEnable()
    {
        base.OnEnable();
        if (photonView.IsMine)
        {
            myReference.audioController = GetComponent<AudioController>();
            print(myReference.audioController);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        print(photonView.ObservedComponents);
        if (stream.IsWriting)
        {
            stream.SendNext(myReference);
        }
        else
        {
            audioController = ((Reference)stream.ReceiveNext()).audioController;
            print(audioController);
        }
    }
}