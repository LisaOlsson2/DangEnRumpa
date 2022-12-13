using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.forward = new Vector3(-cam.transform.forward.x, 0, -cam.transform.forward.z);

        //transform.LookAt(new Vector3(cam.gameObject.transform.position.x, transform.position.y, cam.gameObject.transform.position.z));

        //print(cam.gameObject.transform.forward);

    }
}
