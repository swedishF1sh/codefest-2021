using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpen = false;
    
    void OnTriggerEnter(Collider col)
    {
        isOpen = true;
        if (isOpen = true)
            door.transform.position += new Vector3(10, 0, 0);
        
    }

    void Update()
    {

        //isOpen = false;
        //if (isOpen == false)
        //    door.transform.position = originalPosition;
    }
}
