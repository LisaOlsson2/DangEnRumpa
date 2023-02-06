using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastShadow : MonoBehaviour
{
    [SerializeField]
    GameObject shadow;

    GameObject thing;

    [SerializeField]
    float shadowSize;

    // Start is called before the first frame update
    void Start()
    {
        thing = Instantiate(shadow, transform.position, Quaternion.Euler(90, 0, 0));
        thing.transform.localScale = new Vector3(shadowSize, shadowSize, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit);

        thing.transform.position = hit.point + new Vector3(0, 0.01f, 0);
    }
}
