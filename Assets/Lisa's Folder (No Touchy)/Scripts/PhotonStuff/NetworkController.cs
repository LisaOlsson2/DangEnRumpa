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
    }

    public override void OnConnectedToMaster()
    {
        startButton.interactable = true;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void SetUserName()
    {
        PhotonNetwork.LocalPlayer.NickName = nameField.text;
    }
}

