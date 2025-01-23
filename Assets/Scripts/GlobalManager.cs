using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    
    public static GlobalManager Instance;

    public float gameTimer;
    public int deathCounter;
    public int score;
    public float levelTimer;

    
    public int hookYOffset;
    private bool hasDroppedHook = false;

    public GameObject fishermanHook;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static string ConvertNumbersToString(string inputText)
    {
        string result = "";

        foreach (char c in inputText)
        {
            result += $"<sprite name=\"{c}\"/>";
        }

        return result;
    }
    
    private void Update()
    {
       

        
        
        levelTimer -= Time.deltaTime;  
        gameTimer += Time.deltaTime;
        
        

        if (levelTimer <= 0 && !hasDroppedHook)
        {
           dropHook();
           hasDroppedHook = true;
            
        }
        
    }
    
   


    void dropHook()
    {
         PlayerController.instance.canMove = false;
         PlayerController.instance.canDie = false;
         PlayerController.instance.rb.velocity = Vector3.zero;
         Vector3 hookPos = new Vector3(PlayerController.instance.transform.position.x, PlayerController.instance.transform.position.y + hookYOffset , PlayerController.instance.transform.position.z);
         GameObject hook = Instantiate(fishermanHook, hookPos, Quaternion.Euler(0,0,0));
         
    }
}
