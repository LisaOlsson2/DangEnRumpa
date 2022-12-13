using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicStuff : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
