using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MenuController : MonoBehaviour
{
    public CinemachineVirtualCamera AboveWaterCam;
    public CinemachineVirtualCamera BelowWaterCam;


    private void Start()
    {
        AboveWaterCam.Priority = 11;
        BelowWaterCam.Priority = 10;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (AboveWaterCam.Priority == 11)
            {
                AboveWaterCam.Priority = 10;
                BelowWaterCam.Priority = 11;
            }
            else
            {
                AboveWaterCam.Priority = 11;
                BelowWaterCam.Priority = 10;
            }
        }
    }
}
