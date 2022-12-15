using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NetworkController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    Button startButton;
    [SerializeField]
    InputField nameField;

    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = false;
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting");
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to server in " + PhotonNetwork.CloudRegion);
        startButton.interactable = true;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void SetUserName()
    {
        PhotonNetwork.LocalPlayer.NickName = nameField.text;
    }
}

