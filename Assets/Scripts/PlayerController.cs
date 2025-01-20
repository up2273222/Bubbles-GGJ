using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    //Movement vectors
    private Vector2 mousePosition;
    private Vector2 moveDir;
    
    //Death + Respawn variables
    public Vector3 respawnLocation;
    
    //Sprite variables
    public GameObject spriteHolder;
    
    //Components
    private Rigidbody2D rb;
    
    //Movement values
    [Header("Movement")]
    private bool canMove;
    public float moveSpeed;
    public float maxSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        //Assign components
        rb = GetComponent<Rigidbody2D>();
        
        //Set starting values
        canMove = true;
        
        //DEBUG
        respawnLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement direction
        GetMoveDir();
        //Rotate player sprite to face mouse
        rotatePlayerSprite();
    }

    void FixedUpdate()
    {
        //Clamp Velocity
        CapMoveSpeed();
        //Move player toward mouse cursor if mouse1 is down
        if (Input.GetMouseButton(0) && canMove)
        {
           rb.AddForce(moveDir.normalized * moveSpeed, ForceMode2D.Force);
        }
        
    }

    
    private void GetMoveDir()
    {
        //Calculate move direction
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDir = mousePosition - rb.position;
    }

    private void CapMoveSpeed()
    {
        //Clamp player velocity
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.layer)
        {
            //"Death" layer
            case 6:
                PlayerDeath();
                break;
            //"Checkpoint" layer
            case 7:
                respawnLocation = collision.gameObject.transform.position;
                break;
                
            
        }
        
        
    }
    
   

    private void rotatePlayerSprite()
    {
        spriteHolder.transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg - 90f);
    }
    

    private void PlayerDeath()
    {
        rb.velocity = Vector2.zero;
        canMove = false;
        StartCoroutine(movementCooldown());
        transform.position = respawnLocation;
    }

    private IEnumerator movementCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }
}
