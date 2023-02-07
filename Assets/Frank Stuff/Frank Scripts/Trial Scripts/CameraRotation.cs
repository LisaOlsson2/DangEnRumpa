using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField]
    KeyCode test;

    [SerializeField]
    float rotationSpeed, passiveSpeed, targetRotation;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = passiveSpeed;

        cam = Camera.main;

        cam.fieldOfView = 60;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, rotationSpeed, 0) * Time.deltaTime;

        if (rotationSpeed > passiveSpeed)
        {
            rotationSpeed -= (rotationSpeed - passiveSpeed)/2 * Time.deltaTime * 5;
        }
        else if (rotationSpeed < passiveSpeed)
        {
            rotationSpeed = passiveSpeed;
        }

        //print(transform.eulerAngles.z - 360);

        if (transform.eulerAngles.z > targetRotation + 180)
        {
            
            transform.eulerAngles += new Vector3(0, 0, -(transform.eulerAngles.z - 360) + targetRotation) * Time.deltaTime * 1;
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, targetRotation);
        }

        if (Input.GetKeyDown(test))
        {
            rotationSpeed = 1000;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -20);
            //cam.fieldOfView = 40;
        }
    }
}
