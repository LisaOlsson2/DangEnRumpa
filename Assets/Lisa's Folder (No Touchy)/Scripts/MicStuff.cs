using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MicStuff : MonoBehaviour
{
    PhotonView photonView;
    Photon.Realtime.Player actualPlayer;

    [PunRPC]
    void SetSource(Photon.Realtime.Player player)
    {

    }

    void OnEnable()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Update()
    {

    }
}