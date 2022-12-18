using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MicStuff : MonoBehaviour
{
    PhotonView photonView;
    AudioSource[] mineInOthers = new AudioSource[4];

    void OnEnable()
    {
        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            Destroy(GetComponent<AudioSource>());
        }
    }

    [PunRPC]
    void SetSource()
    {
        print(GetComponent<AudioSource>());
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                photonView.RPC("SetSource", RpcTarget.Others);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                foreach (AudioSource another in mineInOthers)
                {
                    another.clip = Microphone.Start("", false, 100, 44100);
                }

                while (Microphone.GetPosition("") <= 0)
                {
                }

                foreach (AudioSource another in mineInOthers)
                {
                    another.Play();
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Microphone.End("");
            }
        }
    }
}
