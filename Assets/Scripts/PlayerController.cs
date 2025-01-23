using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //Movement vectors
    private Vector2 mousePosition;
    private Vector2 moveDir;
    
    //Death + Respawn variables
    public Vector3 respawnLocation;
    public bool canDie;
    
    //Sprite variables
    public GameObject spriteHolder;
    
    //Components
    public Rigidbody2D rb;
    
    //Movement values
    [Header("Movement")]
    public bool canMove;
    public float moveSpeed;
    public float maxSpeed;

    
    void Start()
    {
        //Assign components
        rb = GetComponent<Rigidbody2D>();
        instance = this;
        
        //Set starting values
        canMove = true;
        canDie = true;
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
            
                
            
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.layer)
        {
             //"Checkpoint" layer
             case 7:
              respawnLocation = other.gameObject.transform.position;
              break;
             //"Jewel" layer
             case 9:
             GlobalManager.Instance.score += 10;
             Destroy(other.gameObject);
             break;
        }   
       
        
    }


    private void rotatePlayerSprite()
    {
        spriteHolder.transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg - 90f);
    }
    

    public void PlayerDeath()
    {
        if (canDie)
        {
           if (GlobalManager.Instance)
           {
            GlobalManager.Instance.deathCounter++;
           }
           rb.velocity = Vector2.zero;
           canMove = false;
           StartCoroutine(movementCooldown());
           transform.position = respawnLocation; 
        }
        
    }

    private IEnumerator movementCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }
}
