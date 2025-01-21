using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    void Start()
    {
      
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (particleSystem.isPlaying == false)
            {
                particleSystem.Play();
            }
            
            
        }
        else
        {
            if (particleSystem.isPlaying == true)
            {
                particleSystem.Stop();
            }
            
        }
    }
}
