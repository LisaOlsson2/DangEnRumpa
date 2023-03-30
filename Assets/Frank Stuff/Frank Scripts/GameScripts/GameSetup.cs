using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameSetup : MonoBehaviour
{
    
    public GameObject playerCharacter, localPlayer;

    /*private void OnPlayerConnected(NetworkPlayer player)
    {
        
    }*/

    // Start is called before the first frame update
    void Awake()
    {
        //localPlayer = Instantiate(playerCharacter, new Vector3(0, 2, 0), Quaternion.identity);

        localPlayer = PhotonNetwork.Instantiate("Player", new Vector3(0, 2, 0), Quaternion.identity);

        PhotonNetwork.Instantiate("Testing Cube", new Vector3(0, 4, 2), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.LogError(PhotonNetwork.CountOfPlayers);
    }
}
