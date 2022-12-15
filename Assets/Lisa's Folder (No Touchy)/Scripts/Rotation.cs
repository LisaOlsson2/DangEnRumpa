using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    void Update()
    {
        transform.forward = new Vector3(player.transform.forward.x, 0, player.transform.forward.z);
    }
}
