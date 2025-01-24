using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
   public GameObject pauseMenu;
   public static bool isPaused;

   private void Start()
   {
      pauseMenu.SetActive(false);
   }

   private void Update()
   {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
         if (isPaused)
         {
            ResumeGame();
         }
         else
         {
            PauseGame();
         }
      }
   }

   public void ResumeGame()
   {
      pauseMenu.SetActive(false);
      Time.timeScale = 1f;
      isPaused = false;
   }

   public void ReturnToMainMenu()
   {
      Time.timeScale = 1f;
      SceneManager.LoadScene(0);
      isPaused = false;
   }

   public void PauseGame()
   {
      pauseMenu.SetActive(true);
      Time.timeScale = 0f;
      isPaused = true;
   }
}
