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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.clip = Microphone.Start("", false, 100, 44100);
            if (photonView.IsMine)
            {
                audioSource.clip = Microphone.Start("", false, 100, 44100);
            }
            
            while (Microphone.GetPosition("") <= 0)
            {
            }

            if (!photonView.IsMine)
            {
                print("playing isn't mine");
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && photonView.IsMine)
        {
            Microphone.End("");
        }
    }
}
