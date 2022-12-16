using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class CharacterStuff : MonoBehaviour
{
    [SerializeField]
    AllSounds soundThingy;

    // Start is called before the first frame update
    public void CreateCharacter()
    {
        soundThingy.allPlayers[0] = PhotonNetwork.Instantiate(Path.Combine("Characters", gameObject.name), Vector3.zero, Quaternion.identity).GetComponent<AudioSource>();
        transform.parent.gameObject.SetActive(false);
    }
}
