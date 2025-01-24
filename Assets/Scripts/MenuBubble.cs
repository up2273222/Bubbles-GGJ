using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Cinemachine;

public class MenuBubble : MonoBehaviour
{
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float mouseForce;
    public float riseSpeed;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * riseSpeed,ForceMode2D.Impulse);

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PopBubble")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
       
       
       

    }

    private void OnMouseOver()
    {
        Vector3 moveDir = transform.position - mousePos;
        rb.AddForce(moveDir.normalized * mouseForce, ForceMode2D.Impulse);
    }
}
