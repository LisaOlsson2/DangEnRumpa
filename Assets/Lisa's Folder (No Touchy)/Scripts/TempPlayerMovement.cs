using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TempPlayerMovement : MonoBehaviour
{
    readonly float speed = 10;

    void OnEnable()
    {
        if (!GetComponent<PhotonView>().IsMine)
        {
            Destroy(this);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }
    }
}