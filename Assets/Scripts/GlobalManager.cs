using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    
    public static GlobalManager Instance;

    public float gameTimer;
    public int deathCounter;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        gameTimer += Time.deltaTime;
    }
}
