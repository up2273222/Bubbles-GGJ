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
    public GameObject harpoon;
    private GameObject harpoonInstance;
    public float harpoonSpeed;
    public float harpoonLifespan;



    void Start()
    {
        isFollowingPlayer = false;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isFollowingPlayer)
        {
            Vector3 movePos = transform.position;
            movePos.x = player.position.x;
            transform.position = movePos;
        }
            
    }

    private void FixedUpdate()
    {
        if (hasShot)
        {
            transform.position += new Vector3(0f, 0.1f, 0f);
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
        GameObject.Destroy(harpoonInstance);
        GameObject.Destroy(this.gameObject);
        
    }

    private void dropHarpoon()
    {
       harpoonInstance = Instantiate(harpoon, transform.position, Quaternion.identity);
       Rigidbody2D _harpoonRB = harpoonInstance.GetComponent<Rigidbody2D>();
       _harpoonRB.AddForce(Vector2.down * harpoonSpeed,ForceMode2D.Impulse);
       StartCoroutine(harpoonLeavePause());
       StartCoroutine(killHarpoon());
       
        
    }
}
