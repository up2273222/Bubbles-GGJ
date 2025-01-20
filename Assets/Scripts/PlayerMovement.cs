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
    public float maxSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        //Assign components
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement direction
        getMoveDir();
    }

    void FixedUpdate()
    {
        //Clamp Velocity
        capMoveSpeed();
        //Move player toward mouse cursor if mouse1 is down
        if (Input.GetMouseButton(0))
        {
           rb.AddForce(moveDir.normalized * moveSpeed, ForceMode2D.Force);
        }
        
    }

    
    private void getMoveDir()
    {
        //Calculate move direction
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDir = mousePosition - rb.position;
    }

    private void capMoveSpeed()
    {
        //Clamp player velocity
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }
    
    
}
