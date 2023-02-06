using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    
    Camera cam;
    GameObject player;

    [SerializeField]
    GameObject rotationChecker;

    public float playerDirectionDiff, trueYRotation;

    SpriteRenderer sr;

    [SerializeField] //0 = forward, 1 = looking right, 2 = back, 3 = looking left
    Sprite[] spriteArray = new Sprite[4];

    [SerializeField]
    bool canRotate;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = FindObjectOfType<PlayerController>().gameObject;

        sr = GetComponent<SpriteRenderer>();

        trueYRotation = transform.localEulerAngles.y;


    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (canRotate)
        {
            rotationChecker.transform.LookAt(player.transform);
            playerDirectionDiff = trueYRotation - rotationChecker.transform.eulerAngles.y;


            //playerDirectionDiff = trueYRotation - player.transform.localEulerAngles.y;


            if (playerDirectionDiff < 0)
            {
                playerDirectionDiff += 360;
            }

            if (playerDirectionDiff < 45 + 5)
            {
                sr.sprite = spriteArray[0];
                //print("0");
            }
            else if (playerDirectionDiff < 135 - 5)
            {
                sr.sprite = spriteArray[1];
                //print("1");
            }
            else if (playerDirectionDiff < 225 + 5)
            {
                sr.sprite = spriteArray[2];
                //print("2");
            }
            else if (playerDirectionDiff < 315 - 5)
            {
                sr.sprite = spriteArray[3];
                //print("3");
            }
            else
            {
                sr.sprite = spriteArray[0];
                //print("0");
            }

            //print(playerDirectionDiff);

        }

        //transform.forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);

        transform.LookAt(new Vector3(cam.gameObject.transform.position.x, transform.position.y, cam.gameObject.transform.position.z));

        transform.localEulerAngles += new Vector3(0, 180, 0);

        //print(cam.gameObject.transform.forward);

    }

    public void SetAnimation(int animation)
    {

    }
}
