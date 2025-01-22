using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{

    private float lifespan = 3f;
    
    void Start()
    {
        
    }

    private void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        transform.position += new Vector3(0, -0.8f, 0);
    }
}
