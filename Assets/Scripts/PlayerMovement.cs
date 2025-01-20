using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    //Movement vectors
    private Vector2 mousePosition;
    private Vector2 moveDir;
    
    //Components
    private Rigidbody2D rb;
    
    //Movement values
    [Header("Movement")]
    public float moveSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getMoveDir();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(moveDir.normalized * moveSpeed, ForceMode2D.Force);
        }
    }

    private void getMoveDir()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDir = mousePosition - rb.position;
    }
    
    
    
}
