using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HarpoonController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private bool isFollowingPlayer;
    private bool hasShot;
    
    public Transform player;
    public float harpoonSpeed;
    public float horizontalSpeed;
    public float harpoonLifespan;



    void Start()
    {
        isFollowingPlayer = false;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
       
            
    }

    private void FixedUpdate()
    {
        if (hasShot)
        {
            transform.position += new Vector3(0f, 0.1f, 0f);
        }
        else if (isFollowingPlayer)
        {
            Vector3 movePos = transform.position;
            movePos.x = Mathf.Lerp(movePos.x, player.position.x, Time.deltaTime * horizontalSpeed);
            transform.position = movePos;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            boxCollider.enabled = false;
            StartCoroutine(harpoonHover());
        }
    }

    private IEnumerator harpoonHover()
    {
        isFollowingPlayer = true;
        yield return new WaitForSeconds(5f);
        isFollowingPlayer = false;
        yield return new WaitForSeconds(0.5f);
        dropHarpoon();
        
    }

    private IEnumerator harpoonLeavePause()
    {
        yield return new WaitForSeconds(0.3f);
        hasShot = true;
    }

    private IEnumerator killHarpoon()
    {
        yield return new WaitForSeconds(harpoonLifespan);
        GameObject.Destroy(this.gameObject);
        
    }

    private void dropHarpoon()
    { 
        
       RaycastHit2D _hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0f, Vector2.down, Mathf.Infinity);
       if ((_hit.collider) && (_hit.collider.gameObject.layer == 3))
       {
           PlayerController.instance.PlayerDeath();
       }
       
        
        
       StartCoroutine(harpoonLeavePause());
       StartCoroutine(killHarpoon());
       
        
    }

    void OnDrawGizmos()
    {
       
    }
}
