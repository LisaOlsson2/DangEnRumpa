using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MicStuff : MonoBehaviour
{
    AudioSource audioSource;
    bool playRegardless;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playRegardless = !playRegardless;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.clip = Microphone.Start("", false, 100, 44100);
            
            while (Microphone.GetPosition("") <= 0)
            {
            }

            if (!GetComponent<PhotonView>().IsMine)
            {
                print("playing isn't mine");
                audioSource.Play();
            }

            if (playRegardless)
            {
                print("playing both");
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Microphone.End("");
        }
    }
}
