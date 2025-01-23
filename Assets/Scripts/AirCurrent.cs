using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCurrent : MonoBehaviour
{

    private AreaEffector2D _ae;
    private void Start()
    {
       _ae = GetComponent<AreaEffector2D>();
        _ae.forceAngle = transform.eulerAngles.z;

    }

    

}
