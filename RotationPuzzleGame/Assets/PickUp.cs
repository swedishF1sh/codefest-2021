﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform destination;
    public float thrust;
    
    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().AddForce(-transform.right * thrust);
    }
}
