using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{

    public Transform transform;
    public float increment = 45f;

    public Vector3 targetRotation;
    public float rotationTime = 1f;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            targetRotation.z += increment;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            targetRotation.z -= increment;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
<<<<<<< HEAD:RotationPuzzleGame/Assets/WorldRotation.cs
            targetRotation.z += increment;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            targetRotation.z -= increment;
=======
            targetRotation.x += increment;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            targetRotation.x -= increment;
>>>>>>> b710d6b800703a4c9ab751fb703eed33bf30defd:codefest-2021-main/RotationPuzzleGame/Assets/Scripts/WorldRotation.cs
        }

        //rotate
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), rotationTime * Time.deltaTime);
       
    }
}