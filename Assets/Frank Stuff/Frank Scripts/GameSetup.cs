using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameSetup : MonoBehaviour
{
    
    public GameObject playerCharacter, localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //localPlayer = Instantiate(playerCharacter, new Vector3(0, 2, 0), Quaternion.identity);

        localPlayer = PhotonNetwork.Instantiate("player", new Vector3(0, 2, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
