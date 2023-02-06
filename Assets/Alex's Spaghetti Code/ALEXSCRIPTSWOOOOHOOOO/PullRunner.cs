using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PullRunner : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    GameObject background;
    Button but1;
    Button but2;
    [SerializeField]
    public string[] commonDrops;
    public string[] RareDrops;
    public string[] LegendaryDrops;
    int pity;
    bool rareGuarantee;
    bool getLegend;
    
    // Start is called before the first frame update
    void Start()
    {
        pity = PlayerPrefs.GetInt("pity");
        rareGuarantee = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if (MonocoinScript.Monocoins >= 100) 
        {
            if(pity >= 100)
            {
                pity = 0;
                rareGuarantee = false;
                getLegend = true;

            }
            else if (pity >= 10 && pity <= 100)
            {
                pity++;
                rareGuarantee = true;
            }
            else
            {
                pity++;
                rareGuarantee = false;

            }
        }
    }

    void Gacha()
    {
        canvas.transform.position += new Vector3(1000, 0, 0);
        background.SetActive(true);
        print("bingus bongus vesp is gay");
    }
}
