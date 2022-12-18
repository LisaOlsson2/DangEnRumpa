using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    public int roomSize;


    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoomNumber = Random.Range(0, 100000);

        RoomOptions options = new()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)roomSize
        };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, options);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public void Cancel()
    {
        PhotonNetwork.LeaveRoom();
    }
}
