﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayBale : MonoBehaviour
{
    Vector3 speed = new Vector3(0,0,20);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime,Space.World);
    }
}