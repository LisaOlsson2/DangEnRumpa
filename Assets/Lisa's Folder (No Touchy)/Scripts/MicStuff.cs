using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MicStuff : MonoBehaviour
{
    PhotonView photonView;
    AudioSource audioSource;

    AllSounds sounds;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        audioSource = GetComponent<AudioSource>();
        sounds = FindObjectOfType<AllSounds>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.clip = Microphone.Start("", false, 100, 44100);

            while (Microphone.GetPosition("") <= 0)
            {
            }

            sounds.Play(0, photonView.IsMine);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Microphone.End("");
        }
    }


}
