using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public List<AudioSource> mineInOthers = new();

    private void Update()
    {
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
