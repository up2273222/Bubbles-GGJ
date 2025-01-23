using System.Collections;
using System.Collections.Generic; using UnityEngine;
public class SpriteFlip : MonoBehaviour { private bool facingRight;
void Update()
{
    mouseFollow();
}
void mouseFollow()
{
    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    difference.Normalize();

    if (difference.x >= 0 && !facingRight)
    { // mouse is on right side of player
        transform.localScale = new Vector3(-2, 2, 1); // or activate look right some other way
        facingRight = true;
    }
    if (difference.x < 0 && facingRight)
    { // mouse is on left side
        transform.localScale = new Vector3(2, 2, 1); // activate looking left
        facingRight = false;
    }
}
}