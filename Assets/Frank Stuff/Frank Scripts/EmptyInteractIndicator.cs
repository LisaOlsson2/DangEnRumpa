using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyInteractIndicator : MonoBehaviour
{
    
    float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
