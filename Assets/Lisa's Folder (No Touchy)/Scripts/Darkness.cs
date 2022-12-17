using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : TempPlayerMovement
{
    int inDarkRooms;

    [SerializeField]
    Sprite sprite;

    SpriteRenderer spriteRenderer;
    Sprite mySprite;

    public override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        mySprite = spriteRenderer.sprite;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (false)
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
        if (false)
        {
            inDarkRooms--;

            if (inDarkRooms < 1)
            {
                spriteRenderer.sprite = mySprite;
            }
        }
    }
}
