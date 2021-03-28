using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform destination;
    public GameObject environment;
    public Rigidbody rigidbody;
    public float thrust;
    public float range = 5;

    bool isPickedUp;
    
    void OnMouseDown()
    {
        /*
        rigidbody.isKinematic = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        */

        isPickedUp = true;

        if(Vector3.Distance(this.transform.position, destination.position) <= range) {
            GetComponent<Rigidbody>().useGravity = false;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = destination.position;
            this.transform.parent = GameObject.Find("Destination").transform;
        }
    }




    void OnMouseUp()
    {
        /*
        rigidbody.isKinematic = false;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        */

        isPickedUp = false;
        rigidbody.constraints = RigidbodyConstraints.None;
        this.transform.parent = environment.transform;
        GetComponent<Rigidbody>().useGravity = true;
        
        this.GetComponent<Rigidbody>().AddForce(-transform.right * thrust);
    }

    
}
