using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTimerHook : MonoBehaviour
{
    public float hookMoveSpeed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - hookMoveSpeed, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.transform.SetParent(gameObject.transform);
            hookMoveSpeed *= -1;
        }
    }


    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
