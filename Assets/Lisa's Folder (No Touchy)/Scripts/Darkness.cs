using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    // enable this script when darkness happens

    [SerializeField]
    Sprite sprite;

    // the lengths of these should be the amount of players
    readonly Sprite[] sprites = new Sprite[3];
    readonly string[] names = new string[3];

    int people;


    private void OnTriggerEnter(Collider other)
    {
        names[people] = other.gameObject.name;
        sprites[people] = other.GetComponent<SpriteRenderer>().sprite;
        people++;
        other.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void OnTriggerExit(Collider other)
    {

        for (int i = 0; i < people + 1; i++)
        {
            if (names[i] == other.gameObject.name)
            {
                other.GetComponent<SpriteRenderer>().sprite = sprites[i];
                sprites[i] = null;
                names[i] = "";

                people--;

                if (i <= people)
                {
                    names[i] = names[people + 1];
                    sprites[i] = sprites[people + 1];
                }
            }
        }
    }
}
