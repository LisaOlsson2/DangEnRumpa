using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;


public class FrankNetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Button startButton;

    [SerializeField]
    TMP_InputField nameField;

    // Start is called before the first frame update
    void Start()
    {

        startButton.interactable = false;
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting...");

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
