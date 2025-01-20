using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UrchinSpike : MonoBehaviour
{
    private Rigidbody2D rb;
    private float lifespan;
    private Vector3 StartPosition;
    public float speed;
    private SpriteRenderer sr;
    private BoxCollider2D boxCol;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifespan = 1.5f;
        StartPosition = transform.position;
        rb.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0f)
        {
            lifespan = 1.5f;
            sr.enabled = true;
            boxCol.enabled = true;
            rb.velocity = Vector2.zero;
            transform.position = StartPosition;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 3)
        {
           
                    sr.enabled = false;
                    boxCol.enabled = false;
        }
        
    }


    private void FixedUpdate()
    {
       transform.position += transform.up * (speed * Time.deltaTime);
 
    }
}