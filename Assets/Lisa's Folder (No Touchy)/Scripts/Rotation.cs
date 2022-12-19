using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        transform.forward = new Vector3(-((GameObject)PhotonNetwork.LocalPlayer.TagObject).transform.forward.x, 0, -((GameObject)PhotonNetwork.LocalPlayer.TagObject).transform.forward.z);
    }
}
