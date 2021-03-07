using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{

    public Transform transform;
    public float increment = 45f;
    public Vector3 rotationVelocity;

    public Vector3 targetRotation;
    public float rotationTime = 1f;
   

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            targetRotation.x += increment;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            targetRotation.x -= increment;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            targetRotation.y += increment;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            targetRotation.y -= increment;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            targetRotation.x = 0;
            targetRotation.y = 0;
            targetRotation.z = 0;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), rotationTime * Time.deltaTime);

    }
}

//when key is pressed, increase rotation velocity to a certain amount and decrease that velocity over time such that a total of 45 degrees is rotated