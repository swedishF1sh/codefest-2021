using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    float xRotation = 0f;
    private bool lockCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float mouseSensitivity = 100f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (lockCursor == false)
                lockCursor = true;
            else
                lockCursor = false;
        }

        if (lockCursor == true)
            Cursor.lockState = CursorLockMode.Locked;
        if (lockCursor == false)
            Cursor.lockState = CursorLockMode.None;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        player.Rotate(Vector3.up * mouseX);
    }
}

