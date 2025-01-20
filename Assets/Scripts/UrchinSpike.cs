using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class UrchinSpike : MonoBehaviour
{
    private Rigidbody2D rb;
    private float lifespan;
    private Vector3 StartPosition;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifespan = 1.5f;
        StartPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0f)
        {
            lifespan = 1.5f;
            transform.position = StartPosition;
        }
       
    }

    private void FixedUpdate()
    {
       
        transform.position += transform.up * (speed * Time.deltaTime);
    }
}