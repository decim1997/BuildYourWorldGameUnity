﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        chaseTarget();
    }

    void chaseTarget()
    {
        this.transform.Translate(Vector3.forward * 0.8f * Time.deltaTime);

    }
}
