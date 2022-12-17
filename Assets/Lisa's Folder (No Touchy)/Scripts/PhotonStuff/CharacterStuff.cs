using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class CharacterStuff : MonoBehaviour
{

    // Start is called before the first frame update
    public void CreateCharacter()
    {
        PhotonNetwork.Instantiate(Path.Combine("Characters", gameObject.name), Vector3.zero, Quaternion.identity);
        transform.parent.gameObject.SetActive(false);
    }
}
