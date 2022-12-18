using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Darkness : TempPlayerMovement
{
    int inDarkRooms;

    [SerializeField]
    Sprite sprite;

    SpriteRenderer spriteRenderer;
    Sprite mySprite;

    void OnEnable()
    {
        if (!GetComponent<PhotonView>().IsMine)
        {
            Destroy(this);
        }
        else
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            mySprite = spriteRenderer.sprite;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (inDarkRooms < 1)
            {
                spriteRenderer.sprite = sprite;
            }

            inDarkRooms++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            inDarkRooms--;

            if (inDarkRooms < 1)
            {
                spriteRenderer.sprite = mySprite;
            }
        }
    }
}
