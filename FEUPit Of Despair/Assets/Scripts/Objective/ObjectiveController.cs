﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Objective"+this.gameObject.transform.position);
    }
}