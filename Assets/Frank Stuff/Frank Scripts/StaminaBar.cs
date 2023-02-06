using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    Slider slider;

    [SerializeField]
    GameObject fill;

    PlayerController pc;


    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        pc = FindObjectOfType<PlayerController>();

        slider.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = pc.stamina;

        if (pc.stamina == 10)
        {
            fill.GetComponent<Image>().color = Color.green;
        }
        else if (pc.stamina > 5)
        {
            fill.GetComponent<Image>().color = Color.cyan;
        }
        else if (pc.stamina > 2)
        {
            fill.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            fill.GetComponent<Image>().color = Color.red;
        }
    }
}
