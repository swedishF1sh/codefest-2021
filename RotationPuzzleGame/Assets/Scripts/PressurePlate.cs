using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    [SerializeField]
    GameObject door2;

    bool isOpen = false;
   
    
    void OnTriggerEnter(Collider col)
    {
        isOpen = true;
        if (isOpen == true)
        {
            door.SetActive(false);
            door2.SetActive(true);
        }

    }
    void OnTriggerExit(Collider colExit)
    {
        door.SetActive(true);
        door2.SetActive(false);
    }


    
   
}
