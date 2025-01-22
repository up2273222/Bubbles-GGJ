using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTimerHook : MonoBehaviour
{
    public float hookMoveSpeed;
    private bool isPaused = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!isPaused)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - hookMoveSpeed, transform.position.z);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            StartCoroutine(ReelBack());
        }
    }


    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        GlobalManager.Instance.deathCounter++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private IEnumerator ReelBack()
    {
        
        PlayerController.instance.gameObject.transform.SetParent(gameObject.transform);
        isPaused = true;
        yield return new WaitForSeconds(0.5f);
        isPaused = false;
        hookMoveSpeed *= -2;
        StartCoroutine(RestartLevel());
          
    }
}
