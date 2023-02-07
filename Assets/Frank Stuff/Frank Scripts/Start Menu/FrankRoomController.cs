using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FrankRoomController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    int sceneIndex;

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        print("We are in a room now");
        StartGame();
    }

    void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            print("Starting Game");
            PhotonNetwork.LoadLevel(sceneIndex);
        }
    }
}
