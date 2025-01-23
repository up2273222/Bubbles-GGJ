using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public CinemachineVirtualCamera AboveWaterCam;
    public CinemachineVirtualCamera BelowWaterCam;

    public GameObject MenuScreen1;
    public GameObject MenuScreen2;

    public Vector3 mousePos;
    
    public float level1Timer;
    public float level2Timer;
    public float level3Timer;
    

    private void Start()
    {

        AboveWaterCam.Priority = 11;
        BelowWaterCam.Priority = 10;
    }
    

    public void LevelSelect()
    {
        AboveWaterCam.Priority = 10;
        BelowWaterCam.Priority = 11;
        MenuScreen1.SetActive(false);
        StartCoroutine(LevelSelectDelay());
    }

    public void BackButton()
    {
        AboveWaterCam.Priority = 11;
        BelowWaterCam.Priority = 10;
        MenuScreen2.SetActive(false);
        StartCoroutine(BackButtonDelay());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        GlobalManager.Instance.levelTimer = level1Timer;
        GlobalManager.Instance.score = 0;
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
        GlobalManager.Instance.levelTimer = level2Timer;
        GlobalManager.Instance.score = 0;
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);  
        GlobalManager.Instance.levelTimer = level3Timer;
        GlobalManager.Instance.score = 0;
                
    }

    private IEnumerator LevelSelectDelay()
    {
        yield return new WaitForSeconds(1f);
        MenuScreen2.SetActive(true);
    }

    private IEnumerator BackButtonDelay()
    {
        yield return new WaitForSeconds(1f);
        MenuScreen1.SetActive(true);
    }
}


