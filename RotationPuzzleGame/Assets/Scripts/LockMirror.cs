using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockMirror : MonoBehaviour
{
   
    public Transform player;
    public Transform camera;
    private bool locked = false;
    public Text LockSign;
    public Text UnlockSign;


    private RaycastHit hit;
    private int numUnlockSigns, numLockSigns;
    public Canvas canvas;
    public void Lock(Rigidbody item)
    {
        item.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        item.isKinematic = true;
       
        locked = true;
    }


    public void Unlock(Rigidbody item)
    {
        item.collisionDetectionMode = CollisionDetectionMode.Continuous;
        
        item.isKinematic = false;
        item.WakeUp();

        locked = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.F))
        {
            if (Physics.Raycast(player.transform.position, camera.transform.forward, out hit, 3))
            {
                var xVelocity = hit.collider.gameObject.GetComponent<Rigidbody>().velocity.x;
                var yVelocity = hit.collider.gameObject.GetComponent<Rigidbody>().velocity.y;
                var zVelocity = hit.collider.gameObject.GetComponent<Rigidbody>().velocity.z;
                if (hit.collider.tag == "Mirror" && Mathf.Abs(xVelocity) < 0.5 && Mathf.Abs(yVelocity) < 0.5 && Mathf.Abs(zVelocity) < 0.5)
                {
                    if (locked == false)
                        Lock(hit.collider.gameObject.GetComponent<Rigidbody>());
                    else
                        Unlock(hit.collider.gameObject.GetComponent<Rigidbody>());
                }
            }

        }
    }
}
