using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int levelTimer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3 && SceneManager.GetActiveScene().buildIndex != 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GlobalManager.Instance.levelTimer = levelTimer;
        }
        else if (other.gameObject.layer == 3 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
    }
}
