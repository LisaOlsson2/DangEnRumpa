using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSounds : MonoBehaviour
{
    public AudioSource[] allPlayers = new AudioSource[2];

    public void Play(int place, bool mine)
    {
        if (!mine)
        {
            allPlayers[place].Play();
        }
        else
        {
            print("no");
        }
    }
}
