using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCurrent : MonoBehaviour
{
    private void Start()
    {
        AreaEffector2D _ae = GetComponent<AreaEffector2D>();
        _ae.forceAngle = 360 - transform.eulerAngles.z;

    }

}
