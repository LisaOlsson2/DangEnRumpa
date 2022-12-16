using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MicStuff : MonoBehaviour
{
    PhotonView photonView;

    AudioSource audioSource;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        audioSource = GetComponent<AudioSource>();

        if (photonView.IsMine)
        {
            Destroy(GetComponent<AudioSource>());
            Destroy(this);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.clip = Microphone.Start("", false, 100, 44100);

            while (Microphone.GetPosition("") <= 0)
            {
            }

            audioSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Microphone.End("");
        }
    }
}
