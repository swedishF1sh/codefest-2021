using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{

    public Transform transform;

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(1, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(-1, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(0, 0, 1);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(0, 0, -1);
    }
}
