using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class FrankLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject roomJoinInput;
    public string joinRoomCode;
    public void RoomCodeInput()
    {
        joinRoomCode = roomJoinInput.GetComponent<TextMeshProUGUI>().text;
    }

    public int roomSize;

    public void JoinRoom()
    {
        print("trying to join");
        if (joinRoomCode != "")
        {
            print("joining " + joinRoomCode);
            PhotonNetwork.JoinRoom(joinRoomCode);
        }
        else
        {
            print("No room code detected");
        }
        
    }



    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Cant find room");
        //CreateRoom();
    }

    public void CreateRoom()
    {
        print("Creating Room");
        int randomRoomNumber = Random.Range(1000, 9999);
        print(randomRoomNumber);

        RoomOptions options = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)roomSize

        };
        PhotonNetwork.CreateRoom("" + randomRoomNumber, options);
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
