using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FrankLobbyCoantroller : MonoBehaviourPunCallbacks
{

    public int roomSize;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        print("Trying to join room");
    }



    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Cant find room");
        CreateRoom();
    }

    void CreateRoom()
    {
        print("Creating Room");
        int randomRoomNumber = Random.Range(0, 1000000);
        print(randomRoomNumber);

        RoomOptions options = new RoomOptions()
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
